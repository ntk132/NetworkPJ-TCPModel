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
    public partial class UpCoinForm : Form
    {
        public String dataStr = "";
        public UpCoinForm()
        {
            InitializeComponent();

            btUpCoin.DialogResult = DialogResult.OK;
        }

        /*******
         * This PRESENT version have NOT supported for pay by card or code
         * Just pay by virtual solution
         * This project is example for the online library
         ********/
        private void btUpCode_Click(object sender, EventArgs e)
        {

        }


        /* Pay by using virtual solution*/
        // Type the textbox much you want to up for this acc
        // Note: less than 25
        private void btUpCoin_Click(object sender, EventArgs e)
        {
            if (tbCoin.Text == "")
            {
                tbCoin.Focus();

                return;
            }

            dataStr = tbCoin.Text;
        }
    }
}
