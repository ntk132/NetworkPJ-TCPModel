namespace Client
{
    partial class BookCart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.btDownload = new System.Windows.Forms.Button();
            this.btView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbTitle.Location = new System.Drawing.Point(25, 10);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(136, 21);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title: Book name";
            // 
            // lbState
            // 
            this.lbState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbState.AutoSize = true;
            this.lbState.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbState.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbState.Location = new System.Drawing.Point(26, 40);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(169, 17);
            this.lbState.TabIndex = 1;
            this.lbState.Text = "State:<paid|new|local>";
            // 
            // lbValue
            // 
            this.lbValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbValue.AutoSize = true;
            this.lbValue.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbValue.Location = new System.Drawing.Point(26, 70);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(95, 17);
            this.lbValue.TabIndex = 2;
            this.lbValue.Text = "Value: 0 Coin";
            // 
            // btDownload
            // 
            this.btDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btDownload.FlatAppearance.BorderSize = 0;
            this.btDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDownload.Image = global::Client.Properties.Resources.download;
            this.btDownload.Location = new System.Drawing.Point(375, 0);
            this.btDownload.Name = "btDownload";
            this.btDownload.Size = new System.Drawing.Size(75, 100);
            this.btDownload.TabIndex = 4;
            this.btDownload.UseVisualStyleBackColor = true;
            // 
            // btView
            // 
            this.btView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btView.FlatAppearance.BorderSize = 0;
            this.btView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btView.Image = global::Client.Properties.Resources.book;
            this.btView.Location = new System.Drawing.Point(300, 0);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(75, 100);
            this.btView.TabIndex = 3;
            this.btView.UseVisualStyleBackColor = true;
            // 
            // BookCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btDownload);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.lbValue);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BookCart";
            this.Size = new System.Drawing.Size(450, 100);
            this.Load += new System.EventHandler(this.BookCart_Load);
            this.MouseLeave += new System.EventHandler(this.BookCart_MouseLeave);
            this.MouseHover += new System.EventHandler(this.BookCart_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.Button btView;
        private System.Windows.Forms.Button btDownload;
    }
}
