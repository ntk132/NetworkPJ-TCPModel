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
    public partial class TransferForm : Form
    {
        public String dataStr = "";

        public TransferForm()
        {
            InitializeComponent();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            // Load file that want to transfer to server
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbBookAddress.Text = ofd.FileName;
            }
        }

        private void btCheckDB_Click(object sender, EventArgs e)
        {
            //
            dataStr = "CHECK|" + tbBookAddress.Text;

            //
        }
    }
}
