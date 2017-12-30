namespace Client
{
    partial class RegisForm
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
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConfirm = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btRegis = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCheckLience = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(157, 67);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(200, 23);
            this.tbPass.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(157, 17);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 23);
            this.tbName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "User name:";
            // 
            // tbConfirm
            // 
            this.tbConfirm.Location = new System.Drawing.Point(157, 117);
            this.tbConfirm.Name = "tbConfirm";
            this.tbConfirm.PasswordChar = '*';
            this.tbConfirm.Size = new System.Drawing.Size(200, 23);
            this.tbConfirm.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Confirm Password:";
            // 
            // btRegis
            // 
            this.btRegis.BackColor = System.Drawing.Color.LightGray;
            this.btRegis.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btRegis.FlatAppearance.BorderSize = 0;
            this.btRegis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRegis.Location = new System.Drawing.Point(282, 215);
            this.btRegis.Name = "btRegis";
            this.btRegis.Size = new System.Drawing.Size(75, 30);
            this.btRegis.TabIndex = 13;
            this.btRegis.Text = "Register";
            this.btRegis.UseVisualStyleBackColor = false;
            this.btRegis.Click += new System.EventHandler(this.btRegis_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(157, 167);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(200, 23);
            this.tbEmail.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Email:";
            // 
            // cbCheckLience
            // 
            this.cbCheckLience.AutoSize = true;
            this.cbCheckLience.Location = new System.Drawing.Point(23, 220);
            this.cbCheckLience.Name = "cbCheckLience";
            this.cbCheckLience.Size = new System.Drawing.Size(148, 21);
            this.cbCheckLience.TabIndex = 18;
            this.cbCheckLience.Text = "I accept this lience";
            this.cbCheckLience.UseVisualStyleBackColor = true;
            this.cbCheckLience.CheckedChanged += new System.EventHandler(this.cbCheckLience_CheckedChanged);
            // 
            // RegisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 261);
            this.Controls.Add(this.cbCheckLience);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btRegis);
            this.Controls.Add(this.tbConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "RegisForm";
            this.ShowIcon = false;
            this.Text = "RegisForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btRegis;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbCheckLience;
    }
}