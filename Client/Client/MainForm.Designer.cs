namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.lvResult = new System.Windows.Forms.ListView();
            this.lbStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btLogout = new System.Windows.Forms.Button();
            this.btRegisAcc = new System.Windows.Forms.Button();
            this.btGoLib = new System.Windows.Forms.Button();
            this.btBookPay = new System.Windows.Forms.Button();
            this.btUpCoin = new System.Windows.Forms.Button();
            this.btAbout = new System.Windows.Forms.Button();
            this.pnResult = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearch.Location = new System.Drawing.Point(106, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(423, 23);
            this.tbSearch.TabIndex = 0;
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.Location = new System.Drawing.Point(535, 13);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 25);
            this.btSearch.TabIndex = 1;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lvResult
            // 
            this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResult.Location = new System.Drawing.Point(106, 41);
            this.lvResult.Name = "lvResult";
            this.lvResult.Scrollable = false;
            this.lvResult.Size = new System.Drawing.Size(504, 150);
            this.lvResult.TabIndex = 2;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.DoubleClick += new System.EventHandler(this.lvResult_DoubleClick);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(5, 12);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 17);
            this.lbStatus.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.btLogout);
            this.panel1.Controls.Add(this.btRegisAcc);
            this.panel1.Controls.Add(this.lbStatus);
            this.panel1.Controls.Add(this.btGoLib);
            this.panel1.Controls.Add(this.btBookPay);
            this.panel1.Controls.Add(this.btUpCoin);
            this.panel1.Controls.Add(this.btAbout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 423);
            this.panel1.TabIndex = 6;
            // 
            // btLogout
            // 
            this.btLogout.Location = new System.Drawing.Point(0, 361);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(100, 50);
            this.btLogout.TabIndex = 5;
            this.btLogout.Text = "Logout";
            this.btLogout.UseVisualStyleBackColor = true;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // btRegisAcc
            // 
            this.btRegisAcc.Location = new System.Drawing.Point(0, 305);
            this.btRegisAcc.Name = "btRegisAcc";
            this.btRegisAcc.Size = new System.Drawing.Size(100, 50);
            this.btRegisAcc.TabIndex = 4;
            this.btRegisAcc.Text = "Regis other Account";
            this.btRegisAcc.UseVisualStyleBackColor = true;
            this.btRegisAcc.Click += new System.EventHandler(this.btRegisAcc_Click);
            // 
            // btGoLib
            // 
            this.btGoLib.Location = new System.Drawing.Point(0, 249);
            this.btGoLib.Name = "btGoLib";
            this.btGoLib.Size = new System.Drawing.Size(100, 50);
            this.btGoLib.TabIndex = 3;
            this.btGoLib.Text = "Go to My Library";
            this.btGoLib.UseVisualStyleBackColor = true;
            this.btGoLib.Click += new System.EventHandler(this.btGoLib_Click);
            // 
            // btBookPay
            // 
            this.btBookPay.Location = new System.Drawing.Point(0, 193);
            this.btBookPay.Name = "btBookPay";
            this.btBookPay.Size = new System.Drawing.Size(100, 50);
            this.btBookPay.TabIndex = 2;
            this.btBookPay.Text = "Transfer new book";
            this.btBookPay.UseVisualStyleBackColor = true;
            this.btBookPay.Click += new System.EventHandler(this.btBookPay_Click);
            // 
            // btUpCoin
            // 
            this.btUpCoin.Location = new System.Drawing.Point(0, 137);
            this.btUpCoin.Name = "btUpCoin";
            this.btUpCoin.Size = new System.Drawing.Size(100, 50);
            this.btUpCoin.TabIndex = 1;
            this.btUpCoin.Text = "Up Coin";
            this.btUpCoin.UseVisualStyleBackColor = true;
            this.btUpCoin.Click += new System.EventHandler(this.btUpCoin_Click);
            // 
            // btAbout
            // 
            this.btAbout.Location = new System.Drawing.Point(0, 81);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(100, 50);
            this.btAbout.TabIndex = 0;
            this.btAbout.Text = "About Account";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // pnResult
            // 
            this.pnResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnResult.BackColor = System.Drawing.Color.White;
            this.pnResult.Location = new System.Drawing.Point(106, 197);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(504, 214);
            this.pnResult.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 423);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbSearch);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.Button btRegisAcc;
        private System.Windows.Forms.Button btGoLib;
        private System.Windows.Forms.Button btBookPay;
        private System.Windows.Forms.Button btUpCoin;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.Panel pnResult;
    }
}