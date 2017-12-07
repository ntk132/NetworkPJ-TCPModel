﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainForm : Form
    {
        private String loginStr;
        private TCPModel tcpClient = new TCPModel();
        private String pathDownload = @"D:\VS 2015\NetworkPJ\Client\Client\Downloads";

        private int pnResultHeight = 0;

        /******** Information of this client ********/
        private String username = "";
        private int coin = 0;

        bool isTransering = false;

        public MainForm()
        {
            InitializeComponent();

            lvResult.View = View.List;
            pnResult.AutoScroll = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            /**** Auto create the connection to server ****/
            // Try to connect to the server
            try
            {
                // get ip address
                String ip = "127.127.100.6";
                // get port number
                int port = 6066;

                tcpClient.ConnectToServer(ip, port);

                Thread t = new Thread(Listener);
                t.Start();
            }
            catch
            {
                // if connecting is failed the turn on the offline mode
                MessageBox.Show("You are offline now!");

                // Send the message to show that this is offline now
                lbStatus.ForeColor = Color.WhiteSmoke;
                lbStatus.Text = "Offline mode!";

                // Every services using network are disable in offline mode
                btBookPay.Enabled = false;
                btRegisAcc.Enabled = false;
                btUpCoin.Enabled = false;

                return;
            }

            /**** Run login form ****/
            RunLoginForm();

            //MessageBox.Show(loginStr);            
        }

        private void RunLoginForm()
        {
            /**** Run login form ****/
            LoginForm lfrm = new LoginForm();

            lfrm.ShowDialog();

            if (lfrm.DialogResult == DialogResult.OK)
            {
                // Get data from login form like: username, password
                loginStr = lfrm.data;
                
                if (loginStr != "")
                    tcpClient.Send_Data("LOGIN|" + loginStr);   // Send login request to server
                else
                    this.Close();   // If user is not login, then close this app
            }
            else if (lfrm.data == "regis")
            {
                RunRegisForm();
            }
            else if (lfrm.data == "exit")
            {
                this.Close();
            }
        }

        // this methos always listen any message from server
        private void Listener(object obj)
        {
            String filename = "";
            while (true)
            {
                if (!isTransering)
                {
                    // Get data
                    String dataIn = tcpClient.Receive_Data(obj);
                    //MessageBox.Show(dataIn);
                    /*if (dataIn == "Start")
                    {
                        filename = tcpClient.Receive_Data(obj);

                        MessageBox.Show(filename);

                        isTransering = true;

                        continue;
                    }
                    else*/ if (dataIn != "" || dataIn != null || dataIn.Length > 0)
                    {
                        //MessageBox.Show(dataIn);
                        ProcessingData(dataIn);
                    }
                }
                else
                {
                    if (tcpClient.ReceiveFile(pathDownload + @"\" + filename) == 1)
                    {
                        MessageBox.Show("Download successfully!");

                        //isTransering = false;
                    }
                    else
                    {
                        MessageBox.Show("Download Failed!");
                    }

                    isTransering = false;
                }
            }
        }

        /// <summary>
        /// This function process the data which receiv from server,
        /// the content is processed to decide which type of message,
        /// then transfer to the suitable method for the next action.
        /// </summary>
        /// <param name="str">ata receive from server</param>
        private void ProcessingData(String str)
        {
            /****
             Recive data include: ACCEPT|username

                - Receice the data from server
                - Get the properties of this data
                - Decide which type of message
             ****/
            string[] temp = str.Split('|');

            switch (temp[0])
            {
                // Receive this after sending login request
                case "LOGIN":
                    if (temp[1] == "ACCEPT")
                    {
                        this.Visible = true;

                        lbStatus.ForeColor = Color.White;
                        lbStatus.Text = "Hi, " + temp[2];

                        username = temp[2];

                        //
                        btBookPay.Enabled = true;
                        btRegisAcc.Enabled = true;
                        btUpCoin.Enabled = true;
                    }
                    else if (temp[1] == "ERROR")
                    {
                        MessageBox.Show(temp[2]);

                        this.Visible = false;

                        RunLoginForm();
                    }

                    break;

                //
                case "REGIS":
                    if (temp[1] == "DONE")
                    {
                        MessageBox.Show("The register is sucessful!");
                    }
                    else if (temp[1] == "ERROR")
                    {
                        MessageBox.Show("Cannot regis! The username is exsisted!");
                    }
                    break;
                // Receive this after sending searching request
                case "SEARCH":
                    if (temp[1] == "ADD")
                    {
                        lvResult.Items.Add(temp[2]);

                        // call the function from other thread or process

                        // Create and add a book cart
                        BookCart bc = new BookCart();
                        bc.Title = temp[2];
                        bc.State = temp[3];
                        bc.Coin = temp[4];
                        bc.Width = pnResult.Width;
                        bc.Location = new Point(0, pnResultHeight);
                        bc.Click += new EventHandler(BookCartItem_Click);
                        pnResultHeight += bc.Height;

                        pnResult.Invoke(new MethodInvoker( delegate {
                                this.pnResult.Controls.Add(bc);
                            }));

                                                
                    }
                    else if (temp[1] == "ERROR")
                    {
                        MessageBox.Show(temp[2]);
                    }
                    break;
                // Receive this after sending view request
                case "VIEW":
                    if (temp[1] == "FOUNDOUT")
                    {
                        OpenFile(temp[2]);
                    }
                    else if (temp[1] == "CANNOT")
                    {
                        MessageBox.Show(temp[2]);
                    }
                    break;
                // Receive this after sending uping coin request
                case "UPCOIN":
                    if (temp[1] == "DONE")
                    {
                        MessageBox.Show("Up coin is Done!");
                    }
                    else if (temp[1] == "CANNOT")
                    {
                        MessageBox.Show(temp[2]);
                    }
                    break;
                // Receive this after sending payment request
                case "PAYMENT":
                    if (temp[1] == "DONE")
                    {
                        isTransering = true;
                        MessageBox.Show("Payment is succssful! The download is in background!");

                        //tcpClient.ReceiveFile(pathDownload + @"\" + temp[2]);

                        //MessageBox.Show("Download successfully!");
                    }
                    else if (temp[1] == "NOTNOUGH")
                    {
                        MessageBox.Show("The current coin is not enough to run this process!");
                    }
                    break;
                default:
                    // SPECIAL CASE: file is sending

                    break;
            }
        }

        /******** This function process the seraching book ********/
        private void btSearch_Click(object sender, EventArgs e)
        {
            // Get the key word of searching
            String dataSearch = tbSearch.Text;

            if (dataSearch != "")
            {
                // Send that to the server to process
                tcpClient.Send_Data("SEARCH|" + dataSearch);
            }            

            // Clear this to ready for receive th list from server
            lvResult.Items.Clear();
            pnResult.Controls.Clear();
            pnResultHeight = 0;
        }


        /******** This function process the double click on a item in listview ********/
        private void lvResult_DoubleClick(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count > 0)
            {
                try
                {
                    // Send the book's name to server
                    tcpClient.Send_Data("VIEW|" + lvResult.SelectedItems[0].Text);
                }
                catch
                {
                    // Exception: this client in offline mode
                    // Can just open book local
                    OpenFile(lvResult.SelectedItems[0].Text);
                }               

            }
        }

        /******** This function process the openning book ********/
        private void OpenFile(String path)
        {
            MessageBox.Show(path);

            //PDFReader pr = new PDFReader(Path.Combine(pathDownload, path));
            //PDFReader pr = new PDFReader(pathDownload + @"\" + path);

            PDFReader pr = new PDFReader();
            pr.path = @"D:\VS 2015\NetworkPJ\Client\Client\Downloads\" + path;
            pr.Show();
        }


        /******** This function process when click a item in panel - list book cart ********/
        private void BookCartItem_Click(object sender, EventArgs e)
        {
            // Get the oject(BookCart) of this function
            BookCart bc = (BookCart)sender;

            /* Test data flow instrument
            MessageBox.Show(bc.Title + "-" + bc.State + "-" + bc.Coin);
            */

            // Mapping properties
            // Send to confim form to make sure the user really want this one
            PaidForm pfrm = new PaidForm(bc.Title, bc.Coin, bc.UseTransfer_Checked);
            pfrm.StartPosition = FormStartPosition.CenterParent;
            if (pfrm.ShowDialog() == DialogResult.OK)
            {
                tcpClient.Send_Data("PAYMENT|" + pfrm.dataStr);
            }

            /*
            // Or send this to server directly
            if (bc.UseTransfer_Checked)
            {
                // Download by useing transfer turn
                tcpClient.Send_Data("PAYMENT|TRANSFER|" + bc.Title);
            }
            else
            {
                // Paying by coin
                tcpClient.Send_Data("PAYMENT|COIN|" + bc.Title + "|" + bc.Coin);
            }
            */      
        }

        private void btAbout_Click(object sender, EventArgs e)
        {

        }

        private void btUpCoin_Click(object sender, EventArgs e)
        {
            UpCoinForm ucfrm = new UpCoinForm();

            ucfrm.StartPosition = FormStartPosition.CenterParent;
            if (ucfrm.ShowDialog() == DialogResult.OK)
            {
                // Send request up th coin to server
                tcpClient.Send_Data("UPCOIN|" + username + "|" + ucfrm.dataStr);
            }            
        }

        private void btBookPay_Click(object sender, EventArgs e)
        {
            TransferForm tffrm = new TransferForm();

            tffrm.StartPosition = FormStartPosition.CenterParent;
            tffrm.ShowDialog();

            tcpClient.Send_Data("TRANSFER|" + tffrm.dataStr);
        }

        private void btGoLib_Click(object sender, EventArgs e)
        {
            /*********
            - Load all files in this folder 
            - This location is the place store all books which downloaded from th server

             ********/
            // Clear the listview
            lvResult.Items.Clear();

            DirectoryInfo direct = new DirectoryInfo(pathDownload);

            foreach (FileInfo files in direct.GetFiles())
            {
                // list all file name in this folder
                lvResult.Items.Add(files.Name);
            }
        }

        private void btRegisAcc_Click(object sender, EventArgs e)
        {
            RunRegisForm();
        }

        private void RunRegisForm()
        {
            RegisForm rfrm = new RegisForm();

            rfrm.StartPosition = FormStartPosition.CenterParent;
            if (rfrm.ShowDialog() == DialogResult.OK)
            {
                tcpClient.Send_Data("REGIS|" + rfrm.regisData);
            }
        }

        private void btLogout_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tcpClient.Disconnect();
            }
            catch
            {
                MessageBox.Show("Cannot close the client!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}