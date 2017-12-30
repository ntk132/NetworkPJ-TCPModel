using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private TCPModel tcpDownloader = new TCPModel();
        private String pathDownload = Environment.CurrentDirectory + @"\Download";
        private String pathCache = Environment.CurrentDirectory + @"\Cache";

        private int pnResultHeight = 0;

        /******** Information of this client ********/
        private String username = "";

        // Variables used for downloading
        bool isTransering = false;
        bool isTrialFile = false;

        private String strTransferPath = "";

        #region Initialize the client with own downloader
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
                int port = 6060;

                // Create the main client
                tcpClient.ConnectToServer(ip, port);

                Thread t = new Thread(Listener);
                t.Start();

                // Create the downloader
                InitDownloader();
            }
            catch
            {
                // if connecting is failed the turn on the offline mode
                MessageBox.Show("You are offline now!");

                // Send the message to show that this is offline now
                lbStatus.ForeColor = Color.WhiteSmoke;
                lbStatus.Text = "Offline mode!";

                // Every services using network are disable in offline mode
                btAbout.Enabled = false;
                btBookPay.Enabled = false;
                btRegisAcc.Enabled = false;
                btUpCoin.Enabled = false;
                btLogout.Enabled = false;

                return;
            }

            /**** Run login form ****/
            RunLoginForm();

            //MessageBox.Show(loginStr);            
        }


        // this methos always listen any message from server
        private void Listener(object obj)
        {
            while (true)
            {
                try
                {
                    // Get data
                    String dataIn = tcpClient.Receive_Data(obj);

                    if (dataIn != "" || dataIn != null || dataIn.Length > 0)
                    {
                        //MessageBox.Show(dataIn);
                        ProcessingData(dataIn);
                    }
                }
                catch
                {

                }
            }
        }
        #endregion

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
            else if (lfrm.data == "-1")
            {
                RunRegisForm();
            }
            else if (lfrm.data == "1" || lfrm.data == "")
            {
                this.Close();
            }
        }


        /// <summary>
        /// This function process the data which receive from server,
        /// the content is processed to decide which type of message,
        /// then transfer to the suitable method for the next action.
        /// </summary>
        /// <param name="str">data receive from server</param>
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
                    // If the account which used to login is onlining
                    // then cannot login by using it.
                    if (temp[1] == "ON")
                    {
                        MessageBox.Show("This account is used by the other! Please try again!");

                        return;
                    }

                    // Else the account have not used
                    if (temp[1] == "ACCEPT")
                    {
                        this.Visible = true;

                        lbStatus.ForeColor = Color.White;
                        lbStatus.Text = "Hi, " + temp[2];

                        username = temp[2];

                        //
                        btAbout.Enabled = true;
                        btBookPay.Enabled = true;
                        btRegisAcc.Enabled = true;
                        btUpCoin.Enabled = true;
                        btLogout.Enabled = true;
                    }
                    else if (temp[1] == "ERROR")    // If wrong password or username
                    {
                        MessageBox.Show(temp[2]);

                        this.Visible = false;

                        // regis again
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
                        CreateBookCart(temp[2], temp[3], temp[4]);
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
                    else if (temp[1] == "TRIAL")
                    {
                        isTrialFile = true;

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
                case "DOWNLOAD":
                    if (temp[1] == "HAVE")
                    {
                        // If this account had download once,
                        // then send the request to download again without payment

                        tcpClient.Send_Data("DOWNLOAD|AGAIN|" + temp[2]);
                    }
                    else if (temp[1] == "NOT")
                    {
                        RunPayForm(temp[2], temp[3]);
                    }
                    break;
                // Receive this after sending payment request
                case "PAYMENT":
                    if (temp[1] == "DONE")
                    {
                        // Create the downloader
                        //InitDownloader();

                        MessageBox.Show("Payment is succssful! The download is in background!");
                    }
                    if (temp[1] == "NOTENOUGH")
                    {
                        MessageBox.Show("The current coin is not enough to run this process!");
                    }
                    if (temp[1] == "OUTTURN")
                    {
                        MessageBox.Show("The turn transfer book is out! Cannot process this!");
                    }
                    break;
                case "TRANSFER":
                    if (temp[1] == "CHECK")
                    {
                        // If the server had
                        if (temp[2] == "HAD")
                        {
                            MessageBox.Show("This book had exsisted in the server!");
                        }
                        else if (temp[2] == "NOT")
                        {
                            // If the server dont have that book
                            MessageBox.Show("Transfering...");

                            tcpClient.Send_Data("TRANSFER|SEND");
                            Downloader_SendingFile(strTransferPath, temp[3]);
                        }
                    }
                    else if (temp[1] == "SEND")
                    {

                    }

                    break;
                case "ABOUT":
                    // Run info form to show the result
                    Info frm = new Info(temp[1], temp[3], temp[4]);

                    frm.StartPosition = FormStartPosition.CenterParent;

                    // Beacause this method is standing a thread which is not the main one
                    // so that using invoke and delegate to run this instrument
                    this.Invoke((MethodInvoker)delegate {
                        frm.ShowDialog();
                    });
                    
                    break;
                default:
                    break;
            }
        }

        #region Creating the book cart (Searching)
        private void CreateBookCart(String title, String state, String coin)
        {
            /* 
                BOOK CART is an user control is create by myself to the info of book in searching-process
                it also privide the buttons to control the request to view trial of book or download book
             */
            // Create and add a book cart
            BookCart bc = new BookCart();

            bc.Title = title;
            bc.State = state;
            bc.Coin = coin;
            bc.OnViewButtonClicked += new EventHandler(ButtonView_Click);   // Setting the view trial button
            bc.OnDownloadButtonClicked += new EventHandler(ButtonDownload_Click);   // Setting the download book
            bc.Width = pnResult.Width;
            bc.Location = new Point(0, pnResultHeight);
            //bc.Click += new EventHandler(BookCartItem_Click);
            pnResultHeight += bc.Height;

            pnResult.Invoke(new MethodInvoker(delegate {
                this.pnResult.Controls.Add(bc);
            }));
        }

        private void ButtonView_Click(object sender, EventArgs e)
        {
            BookCart bc = (BookCart)sender;

            /* Test data flow instrument */
            //MessageBox.Show("View button!");

            // Find book in the local place
            // Get the name of book
            String bookname = bc.Title;

            /**** CASE 1: Search the book in the local Download folder
             ****/

            // Search in local place
            DirectoryInfo dir = new DirectoryInfo(pathDownload);

            foreach (FileInfo file in dir.GetFiles())
            {
                int result = bookname.IndexOf(file.Name);

                // If found out the book
                if (result >= 0)
                {
                    // Open it
                    OpenFile(pathDownload, bookname);

                    return;
                }
            }

            /**** CASE 2: Search the book in the Cache folder
             ****/

            dir = new DirectoryInfo(pathCache);

            foreach (FileInfo file in dir.GetFiles())
            {
                int result = bookname.IndexOf(file.Name);

                // If found out the book
                if (result >= 0)
                {
                    // Open it
                    OpenFile(pathCache, bookname);

                    return;
                }
            }

            /**** CASE 3: Send view trial book request to server
             ****/
            // If not, view on the server(trial)
            //
            String msg = "VIEW|TRIAL|" + bookname;

            tcpClient.Send_Data(msg);

        }

        private void ButtonDownload_Click(object sender, EventArgs e)
        {
            /* Test data flow instrument */
            //MessageBox.Show("Download button");

            // Get the oject(BookCart) of this function
            BookCart bc = (BookCart)sender;

            // Mapping properties
            tcpClient.Send_Data("DOWNLOAD|" + username + "|" + bc.Title + "|" + bc.Coin);
        }

        private void RunPayForm(String title, String coin)
        {
            // Send to confim form to make sure the user really want this one
            PaidForm pfrm = new PaidForm(title, coin);

            pfrm.StartPosition = FormStartPosition.CenterParent;

            if (pfrm.ShowDialog() == DialogResult.OK)
            {
                tcpClient.Send_Data("PAYMENT|" + pfrm.dataStr);
            }
        }

        #endregion

        #region Downloader programming section
        /*****************************************************************************************
        Programming for downloader 
        - Listen and receive the book sent from the server
        - Auto connect to the downloader of server when this client is starting
         *****************************************************************************************/
        private void InitDownloader()
        {
            try
            {
                // Get ip address
                String ip = "127.0.100.6";
                // Get port number
                int port = 6066;

                // Create the downloader
                tcpDownloader.ConnectToServer(ip, port);

                Thread t = new Thread(DownloaderListener);
                t.Start();
            }
            catch
            {
                return;
            }
        }

        // This method always listen any message from server
        private void DownloaderListener(object obj)
        {
            String filename = "";
            String pathFile = "";

            while (true)
            {
                if (!isTransering)
                {
                    // Get data
                    String dataIn = tcpDownloader.Receive_Data(obj);

                    if (dataIn == "Start")
                    {
                        filename = tcpDownloader.Receive_Data(obj);

                        /* Test data flow instrument */
                        //MessageBox.Show(filename);

                        if (isTrialFile) pathFile = pathCache + @"\" + filename;
                        else pathFile = pathDownload + @"\" + filename;

                        // Create the empty file
                        if (!File.Exists(pathFile))
                        {
                            using (StreamWriter sw = File.CreateText(pathFile))
                            {
                                sw.Write("");
                            }
                        }

                        isTransering = true;

                        continue;
                    }
                    if (dataIn == "Trial")
                    {
                        OpenFile(pathFile);
                    }
                }
                else
                {
                    /*
                     CASE: If the server send the trial file,
                            else the server send the paid to download file
                     */
                    // Receive the current data
                    String data = tcpDownloader.Receive_Data(obj);

                    // If the data is still available
                    if (data != "End")
                    {
                        // Update file line
                        using (StreamWriter sw = File.AppendText(pathFile))
                        {
                            sw.WriteLine(data);
                            sw.Close();
                        }

                        // Ready to receive the next one
                        //tcpDownloader.SendDataToClient("Continue", index);
                    }
                    else    // End of sending file (txt)
                    {
                        if (isTrialFile)
                            OpenFile(pathCache, filename);
                        else
                            MessageBox.Show("Download successfully!");
                        /* Reset the sign flag */
                        isTrialFile = false;
                        isTransering = false;
                    }                    
                }
            }
        }

        private void Downloader_SendingFile(String pathFile, String bookname)
        {
            FileStream fs = new FileStream(pathFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            Thread.Sleep(500);

            // Send the start signal
            tcpDownloader.Send_Data("Start");

            Thread.Sleep(250);

            // Send the file
            tcpDownloader.Send_Data(bookname);

            // service only client
            while (!sr.EndOfStream)
            {
                tcpDownloader.Send_Data(sr.ReadLine());

                Thread.Sleep(100);
            }

            sr.Close();
            fs.Close();

            // Send the end signal
            tcpDownloader.Send_Data("End");
        }
        /*****************************************************************************************
         END: the programming for the downloader
        ******************************************************************************************/
        #endregion

        /*****************************************************************************************
        Processing the events when click program button
        and other supported methods.
        
        ******************************************************************************************/
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
                    /* Test data flow instrument */
                    //MessageBox.Show("Open file!");

                    // Exception: this client in offline mode
                    // Can just open book local
                    OpenFile(lvResult.SelectedItems[0].Text);
                }
                catch
                {
                    /* Test data flow instrument */
                    //MessageBox.Show("Send!");

                    // Send the book's name to server                    
                    tcpClient.Send_Data("VIEW|" + lvResult.SelectedItems[0].Text);
                }
            }
        }

        /******** This function process the openning book ********/
        // This function open file which in the download folder
        private void OpenFile(String pathFile)
        {
            //MessageBox.Show(path);

            try
            {
                Process.Start(pathDownload + @"\" + pathFile);
            }
            catch
            {
                MessageBox.Show("Cannot open: " + pathFile);
            }
        }

        private void OpenFile(String pathFolder, String filename)
        {
            //MessageBox.Show(path);

            try
            {
                Process.Start(pathFolder + @"\" + filename);
            }
            catch
            {
                MessageBox.Show("Cannot open: " + filename);
            }
        }

        private void btAbout_Click(object sender, EventArgs e)
        {
            tcpClient.Send_Data("ABOUT|" + username);
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
            // Load file that want to transfer to server
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strTransferPath = ofd.FileName;
                FileInfo file = new FileInfo(ofd.FileName);

                tcpClient.Send_Data("TRANSFER|CHECK|" + file.Name);
            }            
        }

        private void btGoLib_Click(object sender, EventArgs e)
        {
            /*********
            - Load all files in this folder 
            - This location is the place store all books which downloaded from the server
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
            // Disconnect to the server

            // Show login form
            RunLoginForm();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tcpClient.Send_Data("EXIT");

                tcpDownloader.Disconnect();
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
