namespace BarcodeLibTest
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbxBarcode = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.barcode = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gbxBarcode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxBarcode
            // 
            this.gbxBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxBarcode.Controls.Add(this.label2);
            this.gbxBarcode.Controls.Add(this.label1);
            this.gbxBarcode.Controls.Add(this.txtData);
            this.gbxBarcode.Controls.Add(this.pictureBox);
            this.gbxBarcode.Controls.Add(this.barcode);
            this.gbxBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxBarcode.Location = new System.Drawing.Point(0, 0);
            this.gbxBarcode.MinimumSize = new System.Drawing.Size(600, 200);
            this.gbxBarcode.Name = "gbxBarcode";
            this.gbxBarcode.Size = new System.Drawing.Size(628, 361);
            this.gbxBarcode.TabIndex = 0;
            this.gbxBarcode.TabStop = false;
            this.gbxBarcode.Text = "Barcode Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 18;
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(221, 19);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(402, 47);
            this.txtData.TabIndex = 0;
            this.txtData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.enterInTextbox);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 53);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(50, 50);
            this.pictureBox.TabIndex = 14;
            this.pictureBox.TabStop = false;
            // 
            // barcode
            // 
            this.barcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barcode.BackColor = System.Drawing.Color.White;
            this.barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barcode.Location = new System.Drawing.Point(12, 19);
            this.barcode.Name = "barcode";
            this.barcode.Size = new System.Drawing.Size(208, 35);
            this.barcode.TabIndex = 13;
            this.barcode.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 361);
            this.Controls.Add(this.gbxBarcode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(639, 399);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Encoder";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbxBarcode.ResumeLayout(false);
            this.gbxBarcode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.GroupBox gbxBarcode;
        private System.Windows.Forms.PictureBox barcode;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

