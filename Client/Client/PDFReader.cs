using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class PDFReader : Form
    {
        public String path = "";
        public PDFReader()
        {
            InitializeComponent();

            aprReader = new AxAcroPDFLib.AxAcroPDF();
            aprReader.CreateControl();
        }

        public PDFReader(String srcStr)
        {            
        }

        private void PDFReader_Load(object sender, EventArgs e)
        {
            //aprReader.src = path;

            aprReader.LoadFile(@"" + path);
            aprReader.Show();
        }
    }
}
