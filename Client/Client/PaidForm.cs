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
    public partial class PaidForm : Form
    {
        public String dataStr = "";

        public PaidForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pay mode with the parameters is book's name and value
        /// </summary>
        /// <param name="bookname">The name of book</param>
        /// <param name="value">The value of book (count by coin)</param>
        public PaidForm(String bookname, String value)
        {
            InitializeComponent();

            btPay.DialogResult = DialogResult.OK;

            tbBookname.Text = bookname;
            tbBookValue.Text = value;
        }

        private void btPay_Click(object sender, EventArgs e)
        {
            if (cbUTT.Checked)
            {
                dataStr = "TRANSFER|" + tbBookname.Text;
            }
            else
            {
                dataStr = "COIN|" + tbBookname.Text + "|-" + tbBookValue.Text;
            }
        }
    }
}
