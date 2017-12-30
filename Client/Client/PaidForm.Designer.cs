namespace Client
{
    partial class PaidForm
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
            this.cbUTT = new System.Windows.Forms.CheckBox();
            this.btPay = new System.Windows.Forms.Button();
            this.tbBookname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBookValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbUTT
            // 
            this.cbUTT.AutoSize = true;
            this.cbUTT.Location = new System.Drawing.Point(81, 107);
            this.cbUTT.Name = "cbUTT";
            this.cbUTT.Size = new System.Drawing.Size(128, 21);
            this.cbUTT.TabIndex = 8;
            this.cbUTT.Text = "Use transfer turn";
            this.cbUTT.UseVisualStyleBackColor = true;
            // 
            // btPay
            // 
            this.btPay.BackColor = System.Drawing.Color.LightGray;
            this.btPay.FlatAppearance.BorderSize = 0;
            this.btPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPay.Location = new System.Drawing.Point(281, 104);
            this.btPay.Name = "btPay";
            this.btPay.Size = new System.Drawing.Size(75, 25);
            this.btPay.TabIndex = 10;
            this.btPay.Text = "Pay";
            this.btPay.UseVisualStyleBackColor = false;
            this.btPay.Click += new System.EventHandler(this.btPay_Click);
            // 
            // tbBookname
            // 
            this.tbBookname.Location = new System.Drawing.Point(81, 24);
            this.tbBookname.Name = "tbBookname";
            this.tbBookname.Size = new System.Drawing.Size(275, 23);
            this.tbBookname.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Book:";
            // 
            // tbBookValue
            // 
            this.tbBookValue.Location = new System.Drawing.Point(81, 64);
            this.tbBookValue.Name = "tbBookValue";
            this.tbBookValue.Size = new System.Drawing.Size(275, 23);
            this.tbBookValue.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Value:";
            // 
            // PaidForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 151);
            this.Controls.Add(this.cbUTT);
            this.Controls.Add(this.btPay);
            this.Controls.Add(this.tbBookname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBookValue);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PaidForm";
            this.ShowIcon = false;
            this.Text = "PaidForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbUTT;
        private System.Windows.Forms.Button btPay;
        private System.Windows.Forms.TextBox tbBookname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBookValue;
        private System.Windows.Forms.Label label2;
    }
}