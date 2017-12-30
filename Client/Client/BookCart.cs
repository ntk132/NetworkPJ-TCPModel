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
        private Image icon;

        /*
        public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
        public event ButtonClickedEventHandler OnViewButtonClicked;
        public event ButtonClickedEventHandler OnDownloadButtonClicked;
        */

        public event EventHandler OnViewButtonClicked;
        public event EventHandler OnDownloadButtonClicked;

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

        public Image IconType
        {
            get { return icon; }
            set { icon = value; }
        }

        public BookCart()
        {
            InitializeComponent();

            title = "<Unknow>";
            state = "<Unknow>";
            coin = "0";

            pbType.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void BookCart_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
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

            /*
            btView = btnView;
            btDownload = btnDownload;
            */

            btView.Click += new EventHandler(OnButtonViewClicked);
            btDownload.Click += new EventHandler(OnButtonDownloadClicked);
        }

        private void OnButtonViewClicked(object sender, EventArgs e)
        {
            if (OnViewButtonClicked != null)
                OnViewButtonClicked(this, e);
        }

        private void OnButtonDownloadClicked(object sender, EventArgs e)
        {
            if (OnDownloadButtonClicked != null)
                OnDownloadButtonClicked(this, e);
        }

        private void BookCart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Silver);

            g.DrawLine(p, new Point(0, 0), new Point(this.Size.Width, 0));
            g.DrawLine(p, new Point(76, 12), new Point(76, 62));
        }
    }
}
