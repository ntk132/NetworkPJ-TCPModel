using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class LoginForm : Form
    {
        public String data = "";        

        public LoginForm()
        {
            InitializeComponent();
        }        

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tbName.Text != "" && tbPass.Text != "")
            {
                // Get username and password
                // then, send thí to server
                // if accepted, open main form.
                data = tbName.Text + "|" + tbPass.Text;
            }
            else
            {
                if (tbName.Text == "")
                    tbName.Focus();

                if (tbPass.Text == "")
                    tbPass.Focus();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            data = "1";

            this.Close();
        }

        private void btRegis_Click(object sender, EventArgs e)
        {
            data = "-1";

            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
