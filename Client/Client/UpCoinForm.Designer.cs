namespace Client
{
    partial class UpCoinForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbRecharge = new System.Windows.Forms.TextBox();
            this.btUpCode = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btUpCoin = new System.Windows.Forms.Button();
            this.tbCoin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRecharge);
            this.groupBox1.Controls.Add(this.btUpCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Creadit card";
            // 
            // tbRecharge
            // 
            this.tbRecharge.Location = new System.Drawing.Point(61, 22);
            this.tbRecharge.Name = "tbRecharge";
            this.tbRecharge.Size = new System.Drawing.Size(187, 23);
            this.tbRecharge.TabIndex = 1;
            // 
            // btUpCode
            // 
            this.btUpCode.Location = new System.Drawing.Point(254, 22);
            this.btUpCode.Name = "btUpCode";
            this.btUpCode.Size = new System.Drawing.Size(100, 25);
            this.btUpCode.TabIndex = 3;
            this.btUpCode.Text = "Recharge";
            this.btUpCode.UseVisualStyleBackColor = true;
            this.btUpCode.Click += new System.EventHandler(this.btUpCode_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Code:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btUpCoin);
            this.groupBox2.Controls.Add(this.tbCoin);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Virtual up";
            // 
            // btUpCoin
            // 
            this.btUpCoin.Location = new System.Drawing.Point(304, 22);
            this.btUpCoin.Name = "btUpCoin";
            this.btUpCoin.Size = new System.Drawing.Size(50, 25);
            this.btUpCoin.TabIndex = 4;
            this.btUpCoin.Text = "Up";
            this.btUpCoin.UseVisualStyleBackColor = true;
            this.btUpCoin.Click += new System.EventHandler(this.btUpCoin_Click);
            // 
            // tbCoin
            // 
            this.tbCoin.Location = new System.Drawing.Point(55, 23);
            this.tbCoin.Name = "tbCoin";
            this.tbCoin.Size = new System.Drawing.Size(243, 23);
            this.tbCoin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Coin:";
            // 
            // UpCoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 181);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UpCoinForm";
            this.ShowIcon = false;
            this.Text = "UpCoinForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbRecharge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btUpCode;
        private System.Windows.Forms.Button btUpCoin;
        private System.Windows.Forms.TextBox tbCoin;
    }
}