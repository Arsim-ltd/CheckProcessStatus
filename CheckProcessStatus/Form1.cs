using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;


namespace CheckProcessStatus
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Globals.proc.StartInfo = new ProcessStartInfo
            {
                FileName = Globals.process.ToString(),
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Globals.proc.Start();
            Globals.pid = Globals.proc.Id.ToString();

            if (AutoCheckHandlesBox.Checked==true)
            {
                Timer.StartTimer();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleCheck.NewHandleCheck();
            if (AutoCheckHandlesBox.Checked == true)
            {
                Timer.StartTimer();
            }
        }

        private void ProcessBox_TextChanged(object sender, EventArgs e)
        {
            Globals.process = ProcessBox.Text;
        }

        private void PIDBox_TextChanged(object sender, EventArgs e)
        {
            Globals.pid = PIDBox.Text;
        }

    }
}
