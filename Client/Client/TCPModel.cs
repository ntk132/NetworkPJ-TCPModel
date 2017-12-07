﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class TCPModel
    {
        private TcpClient tcp;
        private Stream stm;
        private byte[] dataIn;
        private byte[] dataOut;

        public void ConnectToServer(String ip, int port)
        {
            // Create client
            tcp = new TcpClient();
            
            // start connection
            tcp.Connect(ip, port);
            // set stream for this client
            stm = tcp.GetStream();

            dataIn = new byte[100];
            dataOut = new byte[100];
        }

        /******** Receive data ********/
        public String Receive_Data(object obj)
        {
            try
            {
                // get message from server
                int k = stm.Read(dataIn, 0, 100);

                char[] c = new char[k];
                // Create buffer

                // Transfer the message to string
                // Fill buffer
                for (int i = 0; i < k; i++)
                    c[i] = Convert.ToChar(dataIn[i]);

                /**** TO DO ****/
                return new String(c);
            }
            catch
            {
                return null;
            }
        }

        /******** Send data ********/
        public bool Send_Data(String str)
        {
            try
            {
                // Create buffer

                // Encode the message to byte[]
                ASCIIEncoding asen = new ASCIIEncoding();
                dataOut = asen.GetBytes(str);

                // Send the request to server
                stm.Write(dataOut, 0, dataOut.Length);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public void SendFile(String pathFile)
        {
            byte[] outFile = File.ReadAllBytes(pathFile);
            /*
            using (NetworkStream ns = tcp.GetStream())
            {
                //ns.Write(outFile, 0, outFile.Length);
                //ns.Flush();                
            }
            */

            stm.Write(outFile, 0, outFile.Length);
            stm.Flush();

        }

        public int ReceiveFile(String savePath)
        {
            int thisRead = 0;
            int blockSize = 1024;
            Byte[] dataByte = new Byte[blockSize];

            var ms = new MemoryStream();

            using (NetworkStream ns = tcp.GetStream())
            {
                try
                {
                    while (true)
                    {
                        if (ns.Length <= 0)
                            break;
                        if (!ns.DataAvailable)
                            break;

                        thisRead = ns.Read(dataByte, 0, blockSize);
                        if (thisRead == 0) break;
                        ms.Write(dataByte, 0, thisRead);
                    }

                    File.WriteAllBytes(savePath, ms.ToArray());

                    ns.Close();

                    return 1;
                }
                catch
                {
                    ns.Close();

                    return -1;
                }
            }
        }

        public void Disconnect()
        {
            try
            {
                stm.Close();
                tcp.Close();
            }
            catch
            {
                return;
            }
        }
    }
}
