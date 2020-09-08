using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CheckProcessStatus
{
    static class Program
    {
        static Program()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1();
        }

        public static Form1 form1;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(form1);
        }
    }
}
