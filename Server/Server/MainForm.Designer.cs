namespace Server
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbConnect = new System.Windows.Forms.TextBox();
            this.btGoLib = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // tbIP
            // 
            this.tbIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbIP.Location = new System.Drawing.Point(105, 23);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(200, 23);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "127.127.100.6";
            // 
            // btStart
            // 
            this.btStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btStart.BackColor = System.Drawing.Color.Gainsboro;
            this.btStart.FlatAppearance.BorderSize = 0;
            this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btStart.Location = new System.Drawing.Point(328, 23);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 52);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = false;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbPort
            // 
            this.tbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPort.Location = new System.Drawing.Point(105, 52);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(200, 23);
            this.tbPort.TabIndex = 0;
            this.tbPort.Text = "6060";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Number:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbPort);
            this.groupBox1.Controls.Add(this.btStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 89);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbConnect);
            this.groupBox2.Location = new System.Drawing.Point(20, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 290);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Control";
            // 
            // tbConnect
            // 
            this.tbConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConnect.Location = new System.Drawing.Point(0, 22);
            this.tbConnect.Multiline = true;
            this.tbConnect.Name = "tbConnect";
            this.tbConnect.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConnect.Size = new System.Drawing.Size(410, 268);
            this.tbConnect.TabIndex = 2;
            // 
            // btGoLib
            // 
            this.btGoLib.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btGoLib.BackColor = System.Drawing.Color.Gainsboro;
            this.btGoLib.FlatAppearance.BorderSize = 0;
            this.btGoLib.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGoLib.Location = new System.Drawing.Point(20, 437);
            this.btGoLib.Name = "btGoLib";
            this.btGoLib.Size = new System.Drawing.Size(410, 44);
            this.btGoLib.TabIndex = 7;
            this.btGoLib.Text = "Open Library";
            this.btGoLib.UseVisualStyleBackColor = false;
            this.btGoLib.Click += new System.EventHandler(this.btGoLib_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(448, 493);
            this.Controls.Add(this.btGoLib);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Library Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbConnect;
        private System.Windows.Forms.Button btGoLib;
    }
}