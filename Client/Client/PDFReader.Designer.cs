namespace Client
{
    partial class PDFReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFReader));
            this.aprReader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.aprReader)).BeginInit();
            this.SuspendLayout();
            // 
            // aprReader
            // 
            this.aprReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aprReader.Enabled = true;
            this.aprReader.Location = new System.Drawing.Point(0, 0);
            this.aprReader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aprReader.Name = "aprReader";
            this.aprReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("aprReader.OcxState")));
            this.aprReader.Size = new System.Drawing.Size(784, 561);
            this.aprReader.TabIndex = 0;
            // 
            // PDFReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.aprReader);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PDFReader";
            this.Text = "PDFReader";
            this.Load += new System.EventHandler(this.PDFReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aprReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF aprReader;
    }
}