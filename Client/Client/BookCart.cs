using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class BookCart : UserControl
    {
        private String title;
        private String state;
        private String coin;
        private bool use_trans;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        public String State
        {
            get { return state; }
            set { state = value; }
        }

        public String Coin
        {
            get { return coin; }
            set { coin = value; }
        }

        public bool UseTransfer_Checked
        {
            get { return use_trans; }
            set { use_trans = value; }
        }

        public BookCart()
        {
            InitializeComponent();

            title = "<Unknow>";
            state = "<Unknow>";
            coin = "0";
            use_trans = false;
        }

        private void BookCart_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void BookCart_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void BookCart_Load(object sender, EventArgs e)
        {
            lbTitle.Text = title;
            lbState.Text = state;
            lbValue.Text = coin;
            cbUT.Checked = use_trans;
        }
    }
}
