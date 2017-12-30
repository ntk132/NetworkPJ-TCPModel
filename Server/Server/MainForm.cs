using System;
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
using System.Diagnostics;
/****************************************************************************************************

Project the online library. Using TCP client-server model
Main features:
- Login/Logout
- Register new account
- Up coin for account
- Download book
- View book with trial/full mode
- Upload book to server

    This project will demo by using .txt file system (both database file and book file)

*****************************************************************************************************/
namespace Server
{
    public partial class MainForm : Form
    {
        private TCPModel tcpServer = new TCPModel();
        private TCPModel tcpDownloader = new TCPModel();

        /*
         The DB pathes - This project use the simplest DB - files .txt
         */
        private String pathBookFile = Environment.CurrentDirectory + @"\Data\Book.txt";
        private String pathDownloadFile = Environment.CurrentDirectory + @"\Data\Download.txt";
        private String pathUserFile = Environment.CurrentDirectory + @"\Data\User.txt";
        private String pathBookFolder = Environment.CurrentDirectory + @"\Books";        
        private String pathTrialFolder = Environment.CurrentDirectory + @"\Trials";

        // Variables used for mapping data from DB
        List<String> dataBookFile = new List<string>();
        List<String> dataDownloadFile = new List<string>();
        List<String> dataUserFile = new List<string>();
        List<String> dataBookNameList = new List<string>();
        

        // This list manage the connected users
        List<String> userConnected = new List<string>();

        // Downloader flag
        bool isTransering = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            LoadDB();
        }

        private void LoadDB()
        {
            dataBookNameList = LoadBookNameInDB(pathBookFolder);
            dataBookFile = LoadContentOfFile(pathBookFile);
            dataDownloadFile = LoadContentOfFile(pathDownloadFile);
            dataUserFile = LoadContentOfFile(pathUserFile);            
        }

        #region Init the some features, properties of server (maaping the DB to array string)
        /********  ********  *********  ********/
        // Load the content of a file then save that in the array string,
        // with each operate is a line in the file
        private List<String> LoadContentOfFile(String path)
        {
            List<String> data = new List<String>();

            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                data.Add(sr.ReadLine());
            }

            sr.Close();
            fs.Close();

            return data;
        }

        /********  ********  *********  ********/
        // Load all file name of book in the database (library)
        //
        private List<String> LoadBookNameInDB(String path)
        {
            List<String> result = new List<String>();

            DirectoryInfo direct = new DirectoryInfo(path);

            foreach (FileInfo files in direct.GetFiles())
            {
                result.Add(files.Name);
            }

            return result;
        }
        #endregion

        #region Control the connection to the server
        private void SetConnection(object obj)
        {
            while (true)
            {
                if (tcpServer.AcceptConnection())
                {
                    tbConnect.AppendText(tcpServer.remotEndPoint);

                    Thread t = new Thread(Listener);
                    t.Start(tcpServer.counter - 1);
                }
            }
        }

        private void Listener(object obj)
        {
            int index = (int)obj;

            while (true)
            {
                // Get data
                String dataIn = tcpServer.ReceiveData(obj);

                if (dataIn != "" || dataIn != null || dataIn.Length > 0)
                {
                    //MessageBox.Show(dataIn);
                    ProcessingData(dataIn, (int)obj);
                }
            }
        }
        #endregion

        /**********************************************************************************************/
        /********  ********  *********  ********/
        // Devide the data received from the client
        // then determine which type of that request
        private void ProcessingData(String str, int index)
        {
            /********
             Recive data like:
              - LOGIN|<username>|<password>
              - SEARCH|<keyword>
              - REGIS|<username>|<password>
              - UPCOIN|<coin>
              - VIEW|TRIAL|<bookname>
              - TRANSFER|<CHECK>|<bookname>
             or TRANSFER|<SEND>
              - PAYMENT|<TRANSFER>|<bookname>
             or PAYMENT|<COIN>|<bookname>|<coin>
              - DOWNLOAD|<AGAIN|<bookname>
             or DOWNLOAD|<username>|<bookname>|<coin>
              - ABOUT|<username>
             ********/

            string[] temp;
            
            try
            {
                temp = str.Split('|');
            }
            catch
            {
                return;
            }

            switch (temp[0])
            {
                // If the request is login request,
                // that included: <username>, <password>
                case "LOGIN":
                    if (CheckOnline(temp[1], temp[2]))
                    {
                        // The account is online - connected to server
                        // so that cannot login by using this account
                        String dataOut = "LOGIN|ON|" + temp[1];

                        tcpServer.SendDataToClient(dataOut, index);
                    }
                    else if (CheckAccount(temp[1], temp[2]))
                    {
                        String dataOut = "LOGIN|ACCEPT|" + temp[1];
                        tcpServer.SendDataToClient(dataOut, index);

                        // store the username into the list client
                        if (userConnected.Count <= 1)
                            userConnected.Add(temp[1]);
                        else
                            userConnected[index] = temp[1];

                    }
                    else
                    {
                        String dataOut = "LOGIN|ERROR|Wrong username or password";
                        tcpServer.SendDataToClient(dataOut, index);
                    }
                break;
                case "REGIS":
                    RegisNewAccount(temp[1], temp[2], index);
                break;
                // If the request is search request,
                // then get content to search the book's name
                case "SEARCH":
                    SearchBookNameAndSendResult(temp[1], index);
                break;
                // If the request is want to view a book,
                // then get content to search the book's name
                case "VIEW":
                    // If the request is view trial
                    if (temp[1] == "TRIAL")
                    {
                        ViewBookRequestProcessing(temp[2], index);
                    }
                break;
                case "UPCOIN":
                    UpCoinProcessing(temp[2], index);
                break;
                // The client want to download the book from server
                // using coin in account or the transfer turn
                case "DOWNLOAD":
                    if (temp[1] == "AGAIN")
                    {
                        String pathFile = pathBookFolder + @"\" + temp[2];

                        Downloader_SendingFile(pathFile, temp[2], index);
                    }
                    else
                    {
                        // If the book is paid then the client have not to pay again to download the book
                        CheckDownloadList(temp[1], temp[2], temp[3], index);
                    }
                break;
                case "PAYMENT":
                    if (temp[1] == "TRANSFER")  // Using the free transfer turn to download book
                    {                        
                        TransferBookByTurn(temp[2], index);
                    }
                    else if (temp[1] == "COIN") // Using payment coin to download book
                    {
                        PayCoinToDownloadBook(temp[2], temp[3], index);
                    }

                break;
                case "TRANSFER":
                    if (temp[1] == "CHECK")
                    {
                        //MessageBox.Show("Check:" + temp[2]);

                        CheckBookInDB(temp[2], index);
                    }
                    else if (temp[1] == "SEND")
                    {
                        //MessageBox.Show("Successfully! Transfering in the backdround.");
                    }

                break;
                case "ABOUT":
                    Get_Info_Acc(temp[1], index);
                break;
                default:
                    break;
            }
        }


        #region Checking the account login
        /********  ******** CHECKING ACCOUNT FUCTION *********  ********/
        //
        private bool CheckOnline(String username, String password)
        {
            foreach (String str in userConnected)
            {
                if (str == username)
                    return true;
            }

            return false;
        }

        private bool CheckAccount(String username, String password)
        {
            if (dataUserFile == null)
            {
                FileStream fs = new FileStream(pathUserFile, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    String str = sr.ReadLine();
                    String[] s = str.Split('|');

                    if (s[0] == username && s[1] == password)
                    {
                        return true;
                    }
                }

                sr.Close();
                fs.Close();

                return false;
            }
            else
            {
                foreach (String item in dataUserFile)
                {
                    String str = item;
                    String[] s = str.Split('|');

                    if (s[0] == username && s[1] == password)
                    {
                        return true;
                    }
                }

                return false;
            }
            
        }
        #endregion

        #region Procssing the registion a new account

        #region Regis the new account
        /*                       */
        private void RegisNewAccount(String username, String pass, int index)
        {
            if (InsertAccount(username, pass))
            {
                // Regising is sucessful
                tcpServer.SendDataToClient("REGIS|DONE", index);
                tcpServer.SendDataToClient("LOGIN|ACCEPT|" + username, index);

                // store the username into the list client
                try
                {
                    userConnected[index] = username;
                }
                catch
                {
                    userConnected.Add(username);
                }                
            }
            else
            {
                // The collision about the username
                tcpServer.SendDataToClient("REGIS|ERROR", index);
            }            
        }
        #endregion


        #region Insert a new account when the registion is acceptable
        private bool InsertAccount(String usrn, String pass)
        {
            // Compare the accounts in DB
            foreach (String item in dataUserFile)
            {
                String[] temp = item.Split('|');

                if (temp[0] == usrn)
                {
                    // Find out the same username
                    return false;
                }
            }

            String data = usrn + "|" + pass + "|0|0";

            //FileStream fs = new FileStream(pathUserFile, FileMode.Open);
            using (StreamWriter sw = File.AppendText(pathUserFile))
            {
                //sw.Write(sw.NewLine);
                sw.WriteLine(data);
            }

            // Reload the List String mapping
            dataUserFile = LoadContentOfFile(pathUserFile);

            return true;
        }
        #endregion

        #endregion

        #region Processing the searching the book with getting key word from the client
        /********  ******** SEARCHING FUNCTION *********  ********/
        // With the keyword which get from the client,
        // then return the result to the client
        private void SearchBookNameAndSendResult(String keyword, int index)
        {
            String[] key = new String[4];
            key[0] = keyword;
            key[1] = ConvertAllToUpper(keyword);
            key[2] = ConvertAllToLower(keyword);
            key[3] = ConvertStringToUpperFirstChar(keyword);

            if (ProcessSearchingInDB(key, index) == 0)
                tcpServer.SendDataToClient("SEARCH|ERROR|No item found out!", index);
        }

        // Ver 1: keyword is string
        private int ProcessSearchingInDB(String keyword, int index)
        {
            bool isHavingBook = false;

            foreach (String item in dataBookFile)
            {
                String[] content = item.Split('|');

                int t = content[0].IndexOf(keyword);

                if (t >= 0)
                {
                    Thread.Sleep(50);

                    tcpServer.SendDataToClient("SEARCH|ADD|" + content[0] + "|Free|" + content[1], index);

                    isHavingBook = true;
                }
            }

            if (isHavingBook == false)
                return 0;
            else
                return 1;
        }

        // Ver 2: keyword is array string
        private int ProcessSearchingInDB(String[] keyword, int index)
        {
            bool isHavingBook = false;

            foreach (String item in dataBookFile)
            {
                String[] content = item.Split('|');

                for (int i = 0; i < keyword.Length; i++)
                {
                    int t = content[0].IndexOf(keyword[i]);

                    // Found out the result
                    if (t >= 0)
                    {
                        // Problem in the result,
                        // the clent may receive that 5SEARCH in the value,
                        // so that set the delay to decrease the problem
                        Thread.Sleep(50);

                        String data = "SEARCH|ADD|" + content[0] + "|Not pay|" + content[1];
                        // Send result to The client
                        tcpServer.SendDataToClient( data, index);

                        isHavingBook = true;

                        // Go to next item(Book name) in DB
                        break;
                    }
                }                
            }

            if (isHavingBook == false)
                return 0;
            else
                return 1;
        }

        private string ConvertAllToUpper(String inStr)
        {
            char[] temp = inStr.ToCharArray();

            for (int i = 0; i < inStr.Length; i++)
            {
                if (!Char.IsUpper(temp[i]))
                    temp[i] = Char.ToUpper(temp[i]);
            }

            return new string(temp);
        }

        private string ConvertAllToLower(String inStr)
        {
            char[] temp = inStr.ToCharArray();

            for (int i = 0; i < inStr.Length; i++)
            {
                if (!Char.IsLower(temp[i]))
                    temp[i] = Char.ToLower(temp[i]);
            }

            return new string(temp);
        }

        private string ConvertFirstCharToUpper(String inStr)
        {
            char[] temp = inStr.ToCharArray();

            temp[0] = Char.ToUpper(temp[0]);

            for (int i = 1; i < inStr.Length; i++)
                temp[i] = Char.ToLower(temp[i]);

            return new string(temp);
        }

        private string ConvertStringToUpperFirstChar(String inStr)
        {
            // Get each word from the string
            String[] temp = inStr.Split(' ');

            // Then convert each word to word with first char is uppered
            foreach (String str in temp)
                ConvertFirstCharToUpper(str);

            return String.Join(" ", temp);
        }
        #endregion


        #region Procssing the request view book
        /********  ******** VIEW BOOK FUNCTION *********  ********/
        // With the keyword which get from the client,
        // then return the result to the client
        /// <summary>
        /// VIEW BOOK PROCESSING:
        /// </summary>
        /// <param name="str">It like name of book</param>
        /// <param name="index">index of socket and username</param>
        private void ViewBookRequestProcessing(String str, int index)
        {
            String msg = "VIEW|";

            /******** TO DO *******/
            // Send the trial file of book to client
            tcpServer.SendDataToClient(msg + "TRIAL", index);

            String pathTrial = pathTrialFolder + @"\" + str;

            Downloader_SendingFile(pathTrial, str, index);
        }
        #endregion


        #region Procssing the up coin to account
        /********  ******** UP COIN FUNCTION *********  ********/
        /// <summary>
        /// UP COIN PROCESSING
        /// </summary>
        /// <param name="str">It like the value of coin that the clint want to up</param>
        /// <param name="index">Index of socket and username</param>
        private void UpCoinProcessing(String value, int index)
        {
            String msg = "UPCOIN|";
            // The line type of file user like:
            // <username>|<password>|<coin>

            // 
            UpdateUserInfoDB(dataUserFile, userConnected[index], null, value, null);

            // Message the client that the update is succssful
            tcpServer.SendDataToClient(msg + "DONE", index);
        }
        #endregion


        #region Processing the paying coin to download book
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="bookname"></param>
        /// <param name="index"></param>
        private void CheckDownloadList(String username, String bookname, String coin, int index)
        {
            String data = "DOWNLOAD|";

            foreach (String str in dataDownloadFile)
            {
                String[] temp = str.Split('|');

                if (temp[0] == username && temp[1] == bookname)
                {
                    data += "HAVE|" + bookname;

                    tcpServer.SendDataToClient(data, index);

                    return;
                }
            }

            // else
            data += "NOT|" + bookname + "|" + coin;

            tcpServer.SendDataToClient(data, index);
        }

        /********  ******** PAYMENT FUNCTION *********  ********/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookname"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
        private void PayCoinToDownloadBook(String bookname, String value, int index)
        {
            String msg = "PAYMENT|";
            String pthFl = pathBookFolder + @"\" + bookname;

            // Update DB: user coin, download list
            if (UpdateUserInfoDB(dataUserFile, userConnected[index], null, value, null))
            {
                // Enough coin to pay
                // Payment processing is done
                tcpServer.SendDataToClient(msg + "DONE|" + bookname, index);

                /* Send book to client */
                Downloader_SendingFile(pthFl, bookname, index);

                // Update the DB
                NewBookDownloaded(bookname, userConnected[index]);

                // Update Mapping
                dataDownloadFile = LoadContentOfFile(pathDownloadFile);
            }
            else
            {
                // If coin is not enough
                // Message to the client
                tcpServer.SendDataToClient(msg + "NOTENOUGH", index);
            }
        }
        #endregion

        #region Processing the request get info from client
        private void Get_Info_Acc(String username, int index)
        {
            // Search in DB to find line store the info of userneme
            foreach (String acc in dataUserFile)
            {
                String[] temp = acc.Split('|');

                // Found out the user' info
                // then send the info to the client
                if (temp[0] == username)
                    tcpServer.SendDataToClient("ABOUT|" + acc, index);
            }
        }
        #endregion

        #region Access the DB
        /*         
            UPDATE DB
            (File txt version)
         */
        /// <summary>
        /// Update file DB
        /// </summary>
        /// <param name="filePath">File path - address of source file</param>
        /// <param name="oldContent">The old data (may a line)</param>
        /// <param name="newContent">The replace data</param>
        private void UpdateDB(String filePath, String oldContent,String newContent)
        {
            //string text = File.ReadAllText(filePath);
            string text = File.ReadAllText(filePath);
            text = text.Replace(oldContent, newContent);
            File.WriteAllText(filePath, text);

            LoadDB();
        }

        // Other version of update function
        // Inheritance and Modify from that

        // The line type of file user like:
        // <username>|<password>|<coin>
        /// <summary>
        /// Update the user info
        /// </summary>
        /// <param name="file"></param>
        /// <param name="acc">username</param>
        /// <param name="pass">password</param>
        /// <param name="value">coin value</param>
        private bool UpdateUserInfoDB(List<String> file, String acc, String pass = null, String coin = null, String turn = null)
        {
            foreach (String item in file)
            {
                String[] temp = item.Split('|');

                if (temp[0] == acc)
                {
                    // change password
                    if (pass != null)
                        temp[1] = pass;

                    // update coin
                    if (coin != null)
                    {
                        int total = Convert.ToInt16(temp[2]) + Convert.ToInt16(coin);

                        // Not enough coin to pay
                        if (total < 0)
                        {
                            return false;
                        }

                        temp[2] = total.ToString();
                    }

                    if (turn != null)
                    {
                        int total = Convert.ToInt16(temp[3]) + Convert.ToInt16(turn);

                        // Not enough turn to pay
                        if (total < 0)
                        {
                            return false;
                        }

                        temp[3] = total.ToString();
                    }

                    // Update DB
                    UpdateDB(pathUserFile, item, temp[0] + "|" + temp[1] + "|" + temp[2] + "|" + temp[3]);

                    break;
                }                
            }

            return true;
        }

        private void NewBookUpload(String bookname, int lineNumber)
        {
            int value = 0;

            if (lineNumber <= 5)
                value = 1;
            else if (lineNumber <= 5)
                value = 2;
            else
                value = 5;

            String data = bookname + "|" + value;

            using (StreamWriter sw = File.AppendText(pathBookFile))
            {
                sw.WriteLine(data);
            }

            LoadDB();
        }

        private void NewBookDownloaded(String bookname, String acc)
        {
            String data = acc + "|" + bookname;

            using (StreamWriter sw = File.AppendText(pathDownloadFile))
            {
                sw.WriteLine(data);
            }

            LoadDB();
        }
        #endregion

        #region Processing transfer book
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookname"></param>
        /// <param name="index"></param>
        private void TransferBookByTurn(String bookname, int index)
        {
            String msg = "PAYMENT|";
            String pthFl = pathBookFolder + @"\" + bookname;

            // Update DB: user coin, download list
            if (UpdateUserInfoDB(dataUserFile, userConnected[index], null, null, "-1"))
            {
                // Enough coin to pay
                // Payment processing is done
                tcpServer.SendDataToClient(msg + "DONE|" + bookname, index);

                /* Send book to client */
                Downloader_SendingFile(pthFl, bookname, index);

                // Update the DB
                NewBookDownloaded(bookname, userConnected[index]);

                // Update Mapping
                dataDownloadFile = LoadContentOfFile(pathDownloadFile);
            }
            else
            {
                // If coin is not enough
                // Message to the client
                tcpServer.SendDataToClient(msg + "OUTTURN", index);
            }
        }
        #endregion

        #region Processing upload book
        private void CheckBookInDB(String bookname, int index)
        {
            String dataOut = "TRANSFER|CHECK|";

            foreach (String item in dataBookNameList)
            {
                if (item.IndexOf(bookname) >= 0)
                {
                    dataOut += "HAD";
                    tcpServer.SendDataToClient(dataOut, index);

                    return;
                }
            }

            dataOut += "NOT|" + bookname;
            tcpServer.SendDataToClient(dataOut, index);
        }

        #endregion

        #region Downloader programming
        /****************************************************************************************
         Download Server:
         - Create new TCP server service the download feature
         - the client create new connection to this server to download book
         - The book's info is got from the main server - the library
         *****************************************************************************************/
        private void InitDownloader()
        {
            try
            {
                tcpDownloader.InitServer("127.0.100.6", "6066");

                Thread t = new Thread(SetDownloaderConnection);
                t.Start();
            }
            catch
            {
                tcpDownloader.StopServer();
            }
        }

        private void SetDownloaderConnection(object obj)
        {
            while (true)
            {
                if (tcpDownloader.AcceptConnection())
                {
                    //MessageBox.Show(tcpDownloader.remotEndPoint);

                    Thread t = new Thread(DownloaderListener);
                    //t.Priority = ThreadPriority.Lowest;
                    t.Start(tcpDownloader.counter - 1);
                }
            }
        }

        private void DownloaderListener(object obj)
        {
            int index = (int)obj;
            int lineCount = 0;
            String filename = "";
            String pathFileFull = "";
            String pathFileTrial = "";

            while (true)
            {
                if (!isTransering)
                {
                    // Get data
                    String dataIn = tcpDownloader.ReceiveData(obj);
                    
                    if (dataIn == "Start")
                    {
                        // Get the name of file
                        filename = tcpDownloader.ReceiveData(obj);

                        // Create the pathes
                        //MessageBox.Show(filename);
                        pathFileFull = pathBookFolder + @"\" + filename;
                        pathFileTrial = pathTrialFolder + @"\" + filename;

                        // Create the empty file - full ver
                        if (!File.Exists(pathFileFull))
                        {
                            using (StreamWriter sw = File.CreateText(pathFileFull))
                            {
                                sw.Write("");
                            }
                        }

                        // Create the empty file - trial ver
                        if (!File.Exists(pathFileTrial))
                        {
                            using (StreamWriter sw = File.CreateText(pathFileTrial))
                            {
                                sw.Write("");
                            }
                        }

                        // Ready to receive the content of file
                        isTransering = true;

                        continue;
                    }
                }
                else
                {
                    // Receive the current data
                    String data = tcpDownloader.ReceiveData(obj);

                    // If the data is still available
                    if (data != "End")
                    {
                        // Update file line
                        using (StreamWriter sw = File.AppendText(pathFileFull))
                        {
                            sw.WriteLine(data);
                            lineCount++;
                        }

                        // Ready to receive the next one
                        //tcpDownloader.SendDataToClient("Continue", index);
                    }
                    else    // End of sending file (txt)
                    {
                        // Update info account
                        UpdateUserInfoDB(dataUserFile, userConnected[index], null, null, "1");

                        // Update DB and mapping string
                        NewBookUpload(filename, lineCount);

                        // Create the trial version of this book - txt version
                        CreateTheTrialBookTxt(pathFileFull, pathFileTrial);

                        tbConnect.AppendText("Upload: " + filename + Environment.NewLine);

                        lineCount = 0;
                        isTransering = false;
                    }                    
                }
            }
        }

        private void Downloader_SendingFile(String pathFile, String bookname, int index)
        {
            FileStream fs = new FileStream(pathFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            Thread.Sleep(500);

            // Send the start signal
            tcpDownloader.SendDataToClient("Start", index);

            Thread.Sleep(250);

            // Send the file
            tcpDownloader.SendDataToClient(bookname, index);

            // service only client
            // file's type: pdf

            while (!sr.EndOfStream)
            {
                tcpDownloader.SendDataToClient(sr.ReadLine(), index);

                Thread.Sleep(100);
            }

            sr.Close();
            fs.Close();

            // Send the end signal or the last connected
            tcpDownloader.SendDataToClient("End", index);
        }
        /*****************************************************************************************
         End the programming of the downloader.
        ******************************************************************************************/
        #endregion
            
        #region Create trial file (txt) from the source file
        private void CreateTheTrialBookTxt(string sourcePath, string outputPath)
        {
            try
            {
                // Count the number of pages of this book
                int lineCount = File.ReadAllLines(sourcePath).Count();
                // The number of line of the new trial file which've just created
                int lineGot = 0;

                FileStream fs = new FileStream(sourcePath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                List<String> newData = new List<string>(); 

                /*
                 OWNER RULE: CREATE THE TRIAL FILE (REVIEW BOOK)
                 With the page of book if the number is:
                 < 5   - the trial have 2 lines
                 < 10  - the trial have 4 lines
                 > 50 - the trial have 10 lines
                */
                if (lineCount <= 5)
                {
                    lineGot = 2;
                }
                else if (lineCount <= 10)
                {
                    lineGot = 4;
                }
                else
                {
                    lineGot = 10;
                }
                
                using (StreamWriter sw = new StreamWriter(outputPath))
                {
                    for (int i = 0; i < lineGot; i++)
                        sw.WriteLine(sr.ReadLine());
                }                   

                sr.Close();
                fs.Close();
            }
            catch
            {
                //throw ex;
            }
        }
        #endregion

        private void btGoLib_Click(object sender, EventArgs e)
        {
            Process.Start(pathBookFolder);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tcpDownloader.StopServer();
                tcpServer.StopServer();
            }
            catch
            {
                return;
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Init the main(library) server
                tcpServer.InitServer(tbIP.Text, tbPort.Text);

                // Init the downloader
                InitDownloader();

                Thread t = new Thread(SetConnection);
                t.Start();

                btStart.Text = "Stop";
            }
            catch
            {
                tcpServer.StopServer();
                tcpDownloader.StopServer();

                btStart.Text = "Start";
            }
        }
    }
}
