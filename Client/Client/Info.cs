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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }

        public Info(String user, String coin, String turn)
        {
            InitializeComponent();

            lbName.Text = user;
            lbCoin.Text = coin;
            lbTurn.Text = turn;
        }
    }
}
