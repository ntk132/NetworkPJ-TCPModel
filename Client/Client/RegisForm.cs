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
    public partial class RegisForm : Form
    {
        public String regisData = "";
        public RegisForm()
        {
            InitializeComponent();

            btRegis.DialogResult = DialogResult.OK;
            btRegis.Enabled = false;
        }

        private void cbCheckLience_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckLience.Checked)
                btRegis.Enabled = true;
            else
                btRegis.Enabled = false;
        }

        private void btRegis_Click(object sender, EventArgs e)
        {
            // check for filling full info
            if (tbName.Text == "")
            {
                tbName.Focus();

                return;
            }
            if (tbPass.Text == "")
            {
                tbPass.Focus();

                return;
            }
            if (tbConfirm.Text == "")
            {
                tbConfirm.Focus();

                return;
            }
            if (tbEmail.Text == "")
            {
                tbEmail.Focus();

                return;
            }

            if (tbConfirm.Text != tbPass.Text)
            {
                tbConfirm.Focus();

                return;
            }

            // fill register string for sending to server
            regisData = tbName.Text + "|" + tbPass.Text + "|" + tbEmail.Text;
        }
    }
}
