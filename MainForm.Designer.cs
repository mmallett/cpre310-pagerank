namespace CprE_310_PageRank
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
            this.saveFD = new System.Windows.Forms.SaveFileDialog();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            this.picGen = new System.Windows.Forms.PictureBox();
            this.picSim = new System.Windows.Forms.PictureBox();
            this.picRead = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetPageRanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gettingStartedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRead)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFD
            // 
            this.saveFD.DefaultExt = "txt";
            // 
            // picGen
            // 
            this.picGen.Image = global::CprE_310_PageRank.Properties.Resources.generate;
            this.picGen.Location = new System.Drawing.Point(0, 31);
            this.picGen.Name = "picGen";
            this.picGen.Size = new System.Drawing.Size(425, 151);
            this.picGen.TabIndex = 3;
            this.picGen.TabStop = false;
            this.picGen.Click += new System.EventHandler(this.picGen_Click);
            this.picGen.MouseEnter += new System.EventHandler(this.picGen_MouseEnter);
            this.picGen.MouseLeave += new System.EventHandler(this.picGen_MouseLeave);
            // 
            // picSim
            // 
            this.picSim.Image = global::CprE_310_PageRank.Properties.Resources.simulate;
            this.picSim.Location = new System.Drawing.Point(0, 338);
            this.picSim.Name = "picSim";
            this.picSim.Size = new System.Drawing.Size(425, 151);
            this.picSim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSim.TabIndex = 1;
            this.picSim.TabStop = false;
            this.picSim.Click += new System.EventHandler(this.picSim_Click);
            this.picSim.MouseEnter += new System.EventHandler(this.picSim_MouseEnter);
            this.picSim.MouseLeave += new System.EventHandler(this.picSim_MouseLeave);
            // 
            // picRead
            // 
            this.picRead.Image = global::CprE_310_PageRank.Properties.Resources.binary;
            this.picRead.Location = new System.Drawing.Point(0, 181);
            this.picRead.Name = "picRead";
            this.picRead.Size = new System.Drawing.Size(425, 151);
            this.picRead.TabIndex = 0;
            this.picRead.TabStop = false;
            this.picRead.Click += new System.EventHandler(this.picRead_Click);
            this.picRead.MouseEnter += new System.EventHandler(this.picRead_MouseEnter);
            this.picRead.MouseLeave += new System.EventHandler(this.picRead_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.viewerToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(823, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDataSetToolStripMenuItem,
            this.resetPageRanksToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // deleteDataSetToolStripMenuItem
            // 
            this.deleteDataSetToolStripMenuItem.Name = "deleteDataSetToolStripMenuItem";
            this.deleteDataSetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteDataSetToolStripMenuItem.Text = "Delete Data Set";
            this.deleteDataSetToolStripMenuItem.Click += new System.EventHandler(this.deleteDataSetToolStripMenuItem_Click);
            // 
            // resetPageRanksToolStripMenuItem
            // 
            this.resetPageRanksToolStripMenuItem.Name = "resetPageRanksToolStripMenuItem";
            this.resetPageRanksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetPageRanksToolStripMenuItem.Text = "Reset PageRanks";
            this.resetPageRanksToolStripMenuItem.Click += new System.EventHandler(this.resetPageRanksToolStripMenuItem_Click);
            // 
            // viewerToolStripMenuItem
            // 
            this.viewerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openNewToolStripMenuItem});
            this.viewerToolStripMenuItem.Name = "viewerToolStripMenuItem";
            this.viewerToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.viewerToolStripMenuItem.Text = "Viewer";
            // 
            // openNewToolStripMenuItem
            // 
            this.openNewToolStripMenuItem.Name = "openNewToolStripMenuItem";
            this.openNewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openNewToolStripMenuItem.Text = "Open New";
            this.openNewToolStripMenuItem.Click += new System.EventHandler(this.openNewToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gettingStartedToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // gettingStartedToolStripMenuItem
            // 
            this.gettingStartedToolStripMenuItem.Name = "gettingStartedToolStripMenuItem";
            this.gettingStartedToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.gettingStartedToolStripMenuItem.Text = "Getting Started";
            this.gettingStartedToolStripMenuItem.Click += new System.EventHandler(this.gettingStartedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Location = new System.Drawing.Point(431, 31);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.Size = new System.Drawing.Size(392, 458);
            this.rtbConsole.TabIndex = 6;
            this.rtbConsole.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 491);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.picGen);
            this.Controls.Add(this.picSim);
            this.Controls.Add(this.picRead);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Main | CprE 310 PageRank";
            ((System.ComponentModel.ISupportInitialize)(this.picGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRead)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.SaveFileDialog saveFD;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.PictureBox picRead;
        private System.Windows.Forms.PictureBox picSim;
        private System.Windows.Forms.PictureBox picGen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gettingStartedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataSetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetPageRanksToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.ToolStripMenuItem viewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openNewToolStripMenuItem;
    }
}

