namespace BrainfuckSandbox
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msFile = new System.Windows.Forms.ToolStripMenuItem();
            this.msFile_LoadProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msRun_Run = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Run_RunWithDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStatus = new System.Windows.Forms.StatusStrip();
            this.tsStatusLblLoadedProgram = new System.Windows.Forms.ToolStripStatusLabel();
            this.msMain.SuspendLayout();
            this.tsStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile,
            this.runToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(911, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // msFile
            // 
            this.msFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFile_LoadProgram});
            this.msFile.Name = "msFile";
            this.msFile.Size = new System.Drawing.Size(37, 20);
            this.msFile.Text = "File";
            // 
            // msFile_LoadProgram
            // 
            this.msFile_LoadProgram.Name = "msFile_LoadProgram";
            this.msFile_LoadProgram.Size = new System.Drawing.Size(149, 22);
            this.msFile_LoadProgram.Text = "Load Program";
            this.msFile_LoadProgram.Click += new System.EventHandler(this.msFile_LoadProgram_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msRun_Run,
            this.ms_Run_RunWithDebug});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // msRun_Run
            // 
            this.msRun_Run.Name = "msRun_Run";
            this.msRun_Run.Size = new System.Drawing.Size(176, 22);
            this.msRun_Run.Text = "Run";
            this.msRun_Run.Click += new System.EventHandler(this.msRun_Run_Click);
            // 
            // ms_Run_RunWithDebug
            // 
            this.ms_Run_RunWithDebug.Name = "ms_Run_RunWithDebug";
            this.ms_Run_RunWithDebug.Size = new System.Drawing.Size(176, 22);
            this.ms_Run_RunWithDebug.Text = "Run with Debugger";
            this.ms_Run_RunWithDebug.Click += new System.EventHandler(this.msRun_RunWithDebug_Click);
            // 
            // tsStatus
            // 
            this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLblLoadedProgram});
            this.tsStatus.Location = new System.Drawing.Point(0, 544);
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(911, 22);
            this.tsStatus.TabIndex = 1;
            this.tsStatus.Text = "statusStrip1";
            // 
            // tsStatusLblLoadedProgram
            // 
            this.tsStatusLblLoadedProgram.Name = "tsStatusLblLoadedProgram";
            this.tsStatusLblLoadedProgram.Size = new System.Drawing.Size(101, 17);
            this.tsStatusLblLoadedProgram.Text = "Loaded Program: ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 566);
            this.Controls.Add(this.tsStatus);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "frmMain";
            this.Text = "Brainfuck Sandbox";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsStatus.ResumeLayout(false);
            this.tsStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msFile;
        private System.Windows.Forms.ToolStripMenuItem msFile_LoadProgram;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msRun_Run;
        private System.Windows.Forms.ToolStripMenuItem ms_Run_RunWithDebug;
        private System.Windows.Forms.StatusStrip tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLblLoadedProgram;
    }
}

