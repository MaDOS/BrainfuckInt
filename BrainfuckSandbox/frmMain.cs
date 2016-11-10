using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BrainfuckIntLib;

namespace BrainfuckSandbox
{
    public partial class frmMain : Form
    {
        private BrainfuckIntLib.Program loadedProgram;

        public BrainfuckIntLib.Program LoadedProgram
        {
            get
            {
                return loadedProgram;
            }

            set
            {
                loadedProgram = value;
                this.tsStatusLblLoadedProgram.Text = $"Loaded Program: {value.Name}";
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void msFile_LoadProgram_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(ofd.FileName);
                if(!file.Exists)
                {
                    string message = $"Program does not exist! ### {file.FullName}";
                    Console.WriteLine(message);
                    MessageBox.Show(message);
                    return;
                }

                this.LoadedProgram = new BrainfuckIntLib.Program(file, true);
            }
        }

        private void runToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "brainfuckvm.exe";
            startInfo.Arguments = loadedProgram.File.FullName;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
