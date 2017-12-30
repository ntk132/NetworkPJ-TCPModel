using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class TCPModel
    {
        private TcpListener server;
        private Socket[] socket = new Socket[10];
        private NetworkStream[] networkStream = new NetworkStream[10];
        private IPAddress ipAd;
        private int port;
        public int counter = 0;
        private byte[] dataIn;
        private byte[] dataOut;
        public String remotEndPoint = "";

        public void InitServer(String _ip, String _port)
        {
            // get ip address
            ipAd = IPAddress.Parse(_ip);
            // get port
            port = int.Parse(_port);

            // set server
            server = new TcpListener(ipAd, port);

            // start server
            server.Start();

            dataIn = new byte[1000];
            dataOut = new byte[1000];
        }

        public bool AcceptConnection()
        {
            try
            {
                // Set connection to client
                socket[counter] = server.AcceptSocket();

                try
                {
                    networkStream[counter] = new NetworkStream(socket[counter], true);
                }
                catch
                {
                    networkStream[counter] = new NetworkStream(socket[counter]);
                }

                // get ip of client which've just connected to server
                String str = socket[counter].RemoteEndPoint.ToString();
                str += " is connected." + Environment.NewLine;

                /* Set the thread that always listen the data from client with this index*/

                remotEndPoint = str;

                /* Set connection for the next client*/
                counter++;

                return true;
            }
            catch
            {
                //break;
                return false;
            }
        }

        public void SendDataToClient(String str, int index)
        {
            /* Send the result to the client*/
            dataOut = new byte[1000];

            ASCIIEncoding asen = new ASCIIEncoding();

            // put to buffer
            dataOut = asen.GetBytes(str.ToString());

            Sending(dataOut, index);
        }

        public void Sending(byte[] dataOut, int index)
        {
            try
            {
                // send result to client
                socket[index].Send(dataOut);
            }
            catch
            {

            }          
        }
        
        public void SendDataToAll(String message)
        {
            for (int i = 0; i < counter; i++)
            {
                SendDataToClient(message, i);
            }
        }

        public String ReceiveData(object obj)
        {
            int index = (int)obj;

            try
            {
                //dataIn = new byte[1000];

                // Get message from client
                // k: length of message
                int k = socket[index].Receive(dataIn);

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
                //break;

                return null;
            }
            
        }

        public void StopServer()
        {
            server.Stop();
        }
    }
}
