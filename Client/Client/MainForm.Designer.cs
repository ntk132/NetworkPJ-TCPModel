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
            this.label1 = new System.Windows.Forms.Label();
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
            this.tbSearch.Location = new System.Drawing.Point(169, 13);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(712, 23);
            this.tbSearch.TabIndex = 0;
            // 
            // btSearch
            // 
            this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.btSearch.FlatAppearance.BorderSize = 0;
            this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSearch.Location = new System.Drawing.Point(897, 12);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 25);
            this.btSearch.TabIndex = 1;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = false;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // lvResult
            // 
            this.lvResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResult.Location = new System.Drawing.Point(169, 54);
            this.lvResult.Name = "lvResult";
            this.lvResult.Scrollable = false;
            this.lvResult.Size = new System.Drawing.Size(803, 133);
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
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.label1);
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
            this.panel1.Size = new System.Drawing.Size(150, 561);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(12, 532);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "UIT - Dormteam";
            // 
            // btLogout
            // 
            this.btLogout.BackColor = System.Drawing.Color.Gainsboro;
            this.btLogout.FlatAppearance.BorderSize = 0;
            this.btLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLogout.Image = global::Client.Properties.Resources.logout;
            this.btLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLogout.Location = new System.Drawing.Point(0, 425);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(150, 75);
            this.btLogout.TabIndex = 5;
            this.btLogout.Text = "Logout";
            this.btLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLogout.UseVisualStyleBackColor = false;
            this.btLogout.Click += new System.EventHandler(this.btLogout_Click);
            // 
            // btRegisAcc
            // 
            this.btRegisAcc.BackColor = System.Drawing.Color.Gainsboro;
            this.btRegisAcc.FlatAppearance.BorderSize = 0;
            this.btRegisAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegisAcc.Image = global::Client.Properties.Resources.add_user;
            this.btRegisAcc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRegisAcc.Location = new System.Drawing.Point(0, 350);
            this.btRegisAcc.Name = "btRegisAcc";
            this.btRegisAcc.Size = new System.Drawing.Size(150, 75);
            this.btRegisAcc.TabIndex = 4;
            this.btRegisAcc.Text = "Regiser";
            this.btRegisAcc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRegisAcc.UseVisualStyleBackColor = false;
            this.btRegisAcc.Click += new System.EventHandler(this.btRegisAcc_Click);
            // 
            // btGoLib
            // 
            this.btGoLib.BackColor = System.Drawing.Color.Gainsboro;
            this.btGoLib.FlatAppearance.BorderSize = 0;
            this.btGoLib.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGoLib.Image = global::Client.Properties.Resources.books;
            this.btGoLib.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGoLib.Location = new System.Drawing.Point(0, 275);
            this.btGoLib.Name = "btGoLib";
            this.btGoLib.Size = new System.Drawing.Size(150, 75);
            this.btGoLib.TabIndex = 3;
            this.btGoLib.Text = "My Library";
            this.btGoLib.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGoLib.UseVisualStyleBackColor = false;
            this.btGoLib.Click += new System.EventHandler(this.btGoLib_Click);
            // 
            // btBookPay
            // 
            this.btBookPay.BackColor = System.Drawing.Color.Gainsboro;
            this.btBookPay.FlatAppearance.BorderSize = 0;
            this.btBookPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBookPay.Image = global::Client.Properties.Resources.upload;
            this.btBookPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btBookPay.Location = new System.Drawing.Point(0, 200);
            this.btBookPay.Name = "btBookPay";
            this.btBookPay.Size = new System.Drawing.Size(150, 75);
            this.btBookPay.TabIndex = 2;
            this.btBookPay.Text = "Transfer book";
            this.btBookPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBookPay.UseVisualStyleBackColor = false;
            this.btBookPay.Click += new System.EventHandler(this.btBookPay_Click);
            // 
            // btUpCoin
            // 
            this.btUpCoin.BackColor = System.Drawing.Color.Gainsboro;
            this.btUpCoin.FlatAppearance.BorderSize = 0;
            this.btUpCoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btUpCoin.Image = global::Client.Properties.Resources.coin;
            this.btUpCoin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btUpCoin.Location = new System.Drawing.Point(0, 125);
            this.btUpCoin.Name = "btUpCoin";
            this.btUpCoin.Size = new System.Drawing.Size(150, 75);
            this.btUpCoin.TabIndex = 1;
            this.btUpCoin.Text = "Up Coin";
            this.btUpCoin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btUpCoin.UseVisualStyleBackColor = false;
            this.btUpCoin.Click += new System.EventHandler(this.btUpCoin_Click);
            // 
            // btAbout
            // 
            this.btAbout.BackColor = System.Drawing.Color.Gainsboro;
            this.btAbout.FlatAppearance.BorderSize = 0;
            this.btAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAbout.Image = global::Client.Properties.Resources.information;
            this.btAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbout.Location = new System.Drawing.Point(0, 50);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(150, 75);
            this.btAbout.TabIndex = 0;
            this.btAbout.Text = "About info";
            this.btAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAbout.UseVisualStyleBackColor = false;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // pnResult
            // 
            this.pnResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnResult.BackColor = System.Drawing.Color.White;
            this.pnResult.Location = new System.Drawing.Point(169, 204);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(803, 345);
            this.pnResult.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.tbSearch);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.ShowIcon = false;
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
        private System.Windows.Forms.Label label1;
    }
}