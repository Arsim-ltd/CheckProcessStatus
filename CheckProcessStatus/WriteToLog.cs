using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CheckProcessStatus
{
    class WriteToLog
    {

        public static void Logger(string text)
        {
            using (StreamWriter w = File.AppendText(Globals.pid+".txt"))
            {
                Log(text, w);
            }

        }

        public static void Log(string logMessage, TextWriter w)
        {
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("{0}", logMessage);
            //w.WriteLine("------------------------------------------------------------------------------------");
        }
    }
}
