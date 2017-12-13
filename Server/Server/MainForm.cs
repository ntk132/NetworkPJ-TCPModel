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
using iTextSharp.text;
using iTextSharp.text.pdf;
/****************************************************************************************************
    
    Project the online library. Using TCP client-server model
    Main features:
    - Login/Logout
    - Register new account
    - Up coin for account
    - Download book
    - View book with trial/full mode


*****************************************************************************************************/
namespace Server
{
    public partial class MainForm : Form
    {
        int  MAX_COUNT_BOOK = 1000;
        int MAX_COIN = 25;

        private TCPModel tcpServer = new TCPModel();
        private TCPModel tcpDownloader = new TCPModel();

        /*
         The DB pathes - This project use the simplest DB - files .txt
             */
        private String pathUserFile = @"D:\VS 2015\NetworkPJ\Server\Server\Data\User.txt";
        private String pathBookFolder = @"D:\VS 2015\NetworkPJ\Server\Server\Books";
        private String pathDownload = @"D:\VS 2015\NetworkPJ\Server\Server\Data\Download.txt";

        // Variables used for mapping data from DB
        List<String> dataUserFile;
        List<String> dataBookNameList;
        List<String> dataDownload;

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
            dataUserFile = LoadContentOfFile(pathUserFile);
            dataDownload = LoadContentOfFile(pathDownload);
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
             LOGIN|<username>|<password>
             SEARCH|<content>
             ********/
            string[] temp = str.Split('|');
            

            switch (temp[0])
            {
                // If the request is login request,
                // that included: <username>, <password>
                case "LOGIN":
                    //MessageBox.Show(temp[1] + " - " + temp[2]);
                    if (checkAccount(temp[1], temp[2]))
                    {
                        String dataOut = "LOGIN|ACCEPT|" + temp[1];
                        tcpServer.SendDataToClient(dataOut, index);

                        // store the username into the list client
                        userConnected.Add(temp[1]);
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
                    ViewBookRequestProcessing(temp[1], index);
                    break;
                case "UPCOIN":
                    UpCoinProcessing(temp[2], index);
                    break;
                // The client want to download the book from server
                // using coin in account or the transfer turn
                case "PAYMENT":
                    if (temp[1] == "TRANSFER")
                    {                        
                        TransferBook(temp[2], index);
                    }
                    else if (temp[1] == "COIN")
                    {
                        PayCoinToDownloadBook(temp[2], temp[3], index);
                    }

                    break;
                case "TRANSFER":
                    if (temp[1] == "CHECK")
                    {
                        String dataOut = "TRANSFER|CHECK|";
                        if (CheckBookInDB(temp[2]))
                        {
                            dataOut += "HAD";
                            tcpServer.SendDataToClient(dataOut, index);
                        }
                        else
                        {
                            dataOut += "NOT|" + temp[2];
                            tcpServer.SendDataToClient(dataOut, index);
                        }
                    }
                    else if (temp[1] == "SEND")
                    {
                        MessageBox.Show("Successfully! Transfering in the backdround.");
                    }

                    break;
                default:
                    break;
            }
        }


        #region Checking the account login
        /********  ******** CHECKING ACCOUNT FUCTION *********  ********/
        //
        private bool checkAccount(String username, String password)
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

            String data = usrn + "|" + pass + "|0";

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
            /*
            String key1 = keyword;
            String key2 = ConvertAllToUpper(keyword);
            String key3 = ConvertAllToLower(keyword);
            String key4 = ConvertStringToUpperFirstChar(keyword);
            int r1 =  ProcessSearchingInDB(key1, index);
            int r2 = ProcessSearchingInDB(key2, index);
            int r3 = ProcessSearchingInDB(key3, index);
            int r4 = ProcessSearchingInDB(key4, index);

            if ((r1 + r2 + r3 + r4) == 0)
                tcpServer.SendDataToClient("SEARCH|ERROR|No item found out!", index);
            */

            String[] key = new String[4];
            key[0] = keyword;
            key[1] = ConvertAllToUpper(keyword);
            key[2] = ConvertAllToLower(keyword);
            key[3] = ConvertStringToUpperFirstChar(keyword);

            if (ProcessSearchingInDB(key, index) == 0)
                tcpServer.SendDataToClient("SEARCH|ERROR|No item found out!", index);
        }

        private int ProcessSearchingInDB(String keyword, int index)
        {
            bool isHavingBook = false;

            foreach (String item in dataBookNameList)
            {
                int t = item.IndexOf(keyword);

                if (t >= 0)
                {
                    Thread.Sleep(5);

                    tcpServer.SendDataToClient("SEARCH|ADD|" + item + "|Free|5", index);

                    isHavingBook = true;
                }
            }

            if (isHavingBook == false)
                return 0;
            else
                return 1;
        }

        // Ver 2
        private int ProcessSearchingInDB(String[] keyword, int index)
        {
            bool isHavingBook = false;

            foreach (String item in dataBookNameList)
            {
                for (int i = 0; i < keyword.Length; i++)
                {
                    int t = item.IndexOf(keyword[i]);

                    // Found out the result
                    if (t >= 0)
                    {
                        Thread.Sleep(5);

                        // Send result to The client
                        tcpServer.SendDataToClient("SEARCH|ADD|" + item + "|Free|5", index);

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

            foreach (String item in dataDownload)
            {
                // temp[0]: username
                // temp[1]: book's name
                String[] temp = item.Split('|');

                // Find the username in download list
                if (temp[0] == userConnected[index])
                {
                    // Find out that has this book been downloaded before
                    if (temp[1] == str)
                    {
                        // Tell the client that you downloaded this one
                        tcpServer.SendDataToClient(msg + "FINDOUT|" + str, index);
                        return;
                    }
                }
            }

            // If cannot find out
            // that mine this book is not downloaded
            // Have to pay if want to view full book
            tcpServer.SendDataToClient(msg + "CANNOT|trial", index);
            /******** TO DO *******/
            // Send the trial file of book to client
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
            UpdateUserInfoDB(dataUserFile, userConnected[index], null, value);

            // Message the client that the update is succssful
            tcpServer.SendDataToClient(msg + "DONE", index);
        }
        #endregion


        #region Processing the paying coin to download book
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
            if (UpdateUserInfoDB(dataUserFile, userConnected[index], null, value))
            {
                // Enough coin to pay
                // Payment processing is done
                tcpServer.SendDataToClient(msg + "DONE|" + bookname, index);

                /* Send book to client */
                //SendFileToClient(bookname, index);
                //tcpServer.SendFile(pathBookFolder + @"\" + bookname, index);
                Downloader_SendingFile(pthFl, bookname, index);

                // Update the DB
                NewBookDownloaded(bookname, userConnected[index]);

                // Mapping
                dataDownload = LoadContentOfFile(pathDownload);
            }
            else
            {
                // If coin is not enough
                // Message to the client
                tcpServer.SendDataToClient(msg + "NOTENOUGH", index);
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
        private bool UpdateUserInfoDB(List<String> file, String acc, String pass = null, String value = null)
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
                    if (value != null)
                    {
                        int total = Convert.ToInt16(temp[2]) + Convert.ToInt16(value);

                        // Not enough coin to pay
                        if (total < 0)
                        {
                            return false;
                        }

                        temp[2] = total.ToString();
                    }

                    // Update DB
                    UpdateDB(pathUserFile, item, temp[0] + "|" + temp[1] + "|" + temp[2]);

                    break;
                }                
            }



            return true;
        }

        private void NewBookDownloaded(String bookname, String acc)
        {
            String data = acc + "|" + bookname;

            using (StreamWriter sw = File.AppendText(pathDownload))
            {
                sw.WriteLine(data);
            }

            LoadDB();
        }
#endregion

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookname"></param>
        /// <param name="index"></param>
        private void TransferBook(String bookname, int index)
        {

        }

        #region Processing transfer book
        private bool CheckBookInDB(String bookname)
        {
            foreach (String item in dataBookNameList)
            {
                if (item.IndexOf(bookname) >= 0)
                    return true;
            }

            return false;
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
                    MessageBox.Show(tcpDownloader.remotEndPoint);

                    Thread t = new Thread(DownloaderListener);
                    t.Start(tcpDownloader.counter - 1);
                }
            }
        }

        private void DownloaderListener(object obj)
        {
            int index = (int)obj;
            String filename = "";
            while (true)
            {
                if (!isTransering)
                {
                    // Get data
                    String dataIn = tcpDownloader.ReceiveData(obj);
                    
                    if (dataIn == "Start")
                    {
                        filename = tcpDownloader.ReceiveData(obj);

                        MessageBox.Show(filename);
                        isTransering = true;
                        continue;
                    }
                }
                else
                {
                    if (tcpDownloader.ReceiveFile(pathBookFolder + @"\" + filename, index) == 1)
                    {
                        MessageBox.Show("Download successfully!");                        
                    }
                    else
                    {
                        MessageBox.Show("Download Failed!");
                    }

                    isTransering = false;
                }
            }
        }

        private void Downloader_SendingFile(String pathFile, String bookname, int index)
        {
            Thread.Sleep(500);
            // Send the start signal
            tcpDownloader.SendDataToClient("Start", index);

            // Send the file
            tcpDownloader.SendDataToClient(bookname, index);

            // service only client
            tcpDownloader.SendFile(pathFile, index);

            // Send the end signal or the last connected
            tcpDownloader.SendDataToClient("End", index);
        }
        /*****************************************************************************************
         End the programming of the downloader.
        ******************************************************************************************/
        #endregion


        #region Create trial file (pdf) from the source file
        /**********************************************************************************************
        
        USING: iTextSharp.dll - NuGet package
        SOURCE FROM THIS METHOD: https://www.codeproject.com/Articles/559380/Splitting-and-Merging-PDF-Files-in-Csharp-Using-iT 
        
        ************************************************************************************************/

        public void ExtractPages(string sourcePdfPath, string outputPdfPath, int startPage, int endPage)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the specified range and add the page copies to the output file:
                for (int i = startPage; i <= endPage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Init the main(library) server
                tcpServer.InitServer(tbIP.Text, tbPort.Text);

                // Init the downloader
                InitDownloader();

                Thread t = new Thread(SetConnection);
                t.Start();

                btConnect.Text = "Close";
            }
            catch
            {
                tcpServer.StopServer();

                btConnect.Text = "Connect";
            }
            
        }

        private void btGoLib_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tcpDownloader.StopServer();
                tcpServer.StopServer();

                Application.Exit();
            }
            catch
            {
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
        }
    }
}
