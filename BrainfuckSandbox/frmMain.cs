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
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(ofd.FileName);
                if (!file.Exists)
                {
                    string message = $"Program does not exist! ### {file.FullName}";
                    Console.WriteLine(message);
                    MessageBox.Show(message);
                    return;
                }

                this.LoadedProgram = new BrainfuckIntLib.Program(file, true);
            }
        }

        private void msRun_Run_Click(object sender, EventArgs e)
        {
            this.LoadedProgram.Execute();
        }

        private void msRun_RunWithDebug_Click(object sender, EventArgs e)
        {
        }
    }
}
