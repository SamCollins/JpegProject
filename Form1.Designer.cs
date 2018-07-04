namespace JpegProject
{
    partial class Form1
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
            base.Dispose(disposing);//its free real estate
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yCbCrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dCTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jPEGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showVectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.srcPicture = new System.Windows.Forms.PictureBox();
            this.destPicture = new System.Windows.Forms.PictureBox();
            this.compressImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompressImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.destPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.displayToolStripMenuItem,
            this.analyzeToolStripMenuItem,
            this.jPEGToolStripMenuItem,
            this.motionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // displayToolStripMenuItem
            // 
            this.displayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redComponentToolStripMenuItem,
            this.greenComponentToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.yCbCrToolStripMenuItem,
            this.yToolStripMenuItem,
            this.crToolStripMenuItem,
            this.cbToolStripMenuItem});
            this.displayToolStripMenuItem.Name = "displayToolStripMenuItem";
            this.displayToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.displayToolStripMenuItem.Text = "Display";
            // 
            // redComponentToolStripMenuItem
            // 
            this.redComponentToolStripMenuItem.Name = "redComponentToolStripMenuItem";
            this.redComponentToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.redComponentToolStripMenuItem.Text = "Red";
            this.redComponentToolStripMenuItem.Click += new System.EventHandler(this.redComponentToolStripMenuItem_Click);
            // 
            // greenComponentToolStripMenuItem
            // 
            this.greenComponentToolStripMenuItem.Name = "greenComponentToolStripMenuItem";
            this.greenComponentToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.greenComponentToolStripMenuItem.Text = "Green";
            this.greenComponentToolStripMenuItem.Click += new System.EventHandler(this.greenComponentToolStripMenuItem_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.blueToolStripMenuItem.Text = "Blue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // yCbCrToolStripMenuItem
            // 
            this.yCbCrToolStripMenuItem.Name = "yCbCrToolStripMenuItem";
            this.yCbCrToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.yCbCrToolStripMenuItem.Text = "YCbCr";
            this.yCbCrToolStripMenuItem.Click += new System.EventHandler(this.yCbCrToolStripMenuItem_Click);
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.yToolStripMenuItem.Text = "Y";
            this.yToolStripMenuItem.Click += new System.EventHandler(this.yToolStripMenuItem_Click);
            // 
            // crToolStripMenuItem
            // 
            this.crToolStripMenuItem.Name = "crToolStripMenuItem";
            this.crToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.crToolStripMenuItem.Text = "Cr";
            this.crToolStripMenuItem.Click += new System.EventHandler(this.crToolStripMenuItem_Click);
            // 
            // cbToolStripMenuItem
            // 
            this.cbToolStripMenuItem.Name = "cbToolStripMenuItem";
            this.cbToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.cbToolStripMenuItem.Text = "Cb";
            this.cbToolStripMenuItem.Click += new System.EventHandler(this.cbToolStripMenuItem_Click);
            // 
            // analyzeToolStripMenuItem
            // 
            this.analyzeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dCTToolStripMenuItem});
            this.analyzeToolStripMenuItem.Name = "analyzeToolStripMenuItem";
            this.analyzeToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyzeToolStripMenuItem.Text = "Analyze";
            // 
            // dCTToolStripMenuItem
            // 
            this.dCTToolStripMenuItem.Name = "dCTToolStripMenuItem";
            this.dCTToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.dCTToolStripMenuItem.Text = "DCT";
            this.dCTToolStripMenuItem.Click += new System.EventHandler(this.dCTToolStripMenuItem_Click);
            // 
            // jPEGToolStripMenuItem
            // 
            this.jPEGToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressImageToolStripMenuItem,
            this.decompressImageToolStripMenuItem});
            this.jPEGToolStripMenuItem.Name = "jPEGToolStripMenuItem";
            this.jPEGToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.jPEGToolStripMenuItem.Text = "JPEG";
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showVectorsToolStripMenuItem});
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.motionToolStripMenuItem.Text = "Motion";
            // 
            // showVectorsToolStripMenuItem
            // 
            this.showVectorsToolStripMenuItem.Name = "showVectorsToolStripMenuItem";
            this.showVectorsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.showVectorsToolStripMenuItem.Text = "Show Vectors";
            this.showVectorsToolStripMenuItem.Click += new System.EventHandler(this.showVectorsToolStripMenuItem_Click);
            // 
            // srcPicture
            // 
            this.srcPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.srcPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.srcPicture.Location = new System.Drawing.Point(20, 40);
            this.srcPicture.Name = "srcPicture";
            this.srcPicture.Size = new System.Drawing.Size(256, 256);
            this.srcPicture.TabIndex = 1;
            this.srcPicture.TabStop = false;
            this.srcPicture.Click += new System.EventHandler(this.srcPicture_Click);
            // 
            // destPicture
            // 
            this.destPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.destPicture.Location = new System.Drawing.Point(316, 40);
            this.destPicture.Name = "destPicture";
            this.destPicture.Size = new System.Drawing.Size(256, 256);
            this.destPicture.TabIndex = 2;
            this.destPicture.TabStop = false;
            this.destPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.destPicture_Paint);
            // 
            // compressImageToolStripMenuItem
            // 
            this.compressImageToolStripMenuItem.Name = "compressImageToolStripMenuItem";
            this.compressImageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.compressImageToolStripMenuItem.Text = "Compress Image";
            this.compressImageToolStripMenuItem.Click += new System.EventHandler(this.compressImageToolStripMenuItem_Click);
            // 
            // decompressImageToolStripMenuItem
            // 
            this.decompressImageToolStripMenuItem.Name = "decompressImageToolStripMenuItem";
            this.decompressImageToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.decompressImageToolStripMenuItem.Text = "Decompress Image";
            this.decompressImageToolStripMenuItem.Click += new System.EventHandler(this.decompressImageToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 329);
            this.Controls.Add(this.destPicture);
            this.Controls.Add(this.srcPicture);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.destPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.PictureBox srcPicture;
        private System.Windows.Forms.PictureBox destPicture;
        private System.Windows.Forms.ToolStripMenuItem displayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yCbCrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dCTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jPEGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showVectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decompressImageToolStripMenuItem;
    }
}

