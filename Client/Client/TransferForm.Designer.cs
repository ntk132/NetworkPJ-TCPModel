namespace Client
{
    partial class TransferForm
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
            this.gbTransfer = new System.Windows.Forms.GroupBox();
            this.btCheckDB = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.tbBookAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbTransfer.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTransfer
            // 
            this.gbTransfer.Controls.Add(this.btCheckDB);
            this.gbTransfer.Controls.Add(this.btLoad);
            this.gbTransfer.Controls.Add(this.tbBookAddress);
            this.gbTransfer.Controls.Add(this.label3);
            this.gbTransfer.Location = new System.Drawing.Point(12, 12);
            this.gbTransfer.Name = "gbTransfer";
            this.gbTransfer.Size = new System.Drawing.Size(360, 100);
            this.gbTransfer.TabIndex = 1;
            this.gbTransfer.TabStop = false;
            this.gbTransfer.Text = "Transfer book";
            // 
            // btCheckDB
            // 
            this.btCheckDB.Location = new System.Drawing.Point(101, 51);
            this.btCheckDB.Name = "btCheckDB";
            this.btCheckDB.Size = new System.Drawing.Size(150, 25);
            this.btCheckDB.TabIndex = 5;
            this.btCheckDB.Text = "Check Server DB";
            this.btCheckDB.UseVisualStyleBackColor = true;
            this.btCheckDB.Click += new System.EventHandler(this.btCheckDB_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(304, 21);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(50, 25);
            this.btLoad.TabIndex = 2;
            this.btLoad.Text = "Load";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // tbBookAddress
            // 
            this.tbBookAddress.Location = new System.Drawing.Point(101, 22);
            this.tbBookAddress.Name = "tbBookAddress";
            this.tbBookAddress.Size = new System.Drawing.Size(200, 23);
            this.tbBookAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Load book:";
            // 
            // TransferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 131);
            this.Controls.Add(this.gbTransfer);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TransferForm";
            this.Text = "TransferForm";
            this.gbTransfer.ResumeLayout(false);
            this.gbTransfer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTransfer;
        private System.Windows.Forms.Button btCheckDB;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.TextBox tbBookAddress;
        private System.Windows.Forms.Label label3;
    }
}