using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows;
using System.Diagnostics;

namespace CheckProcessStatus
{
    public static class HandlesStuff
    {
        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.Dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);

        public static List<IntPtr> GetHandle(string args)
        {

            string stringPid = args;
            int pid = Convert.ToInt32(stringPid);
            List<IntPtr> windowlist = GetRootWindowsOfProcess(pid);
            
            return windowlist;
        }

        static List<IntPtr> GetRootWindowsOfProcess(int pid)
        {
            List<IntPtr> rootWindows = GetChildWindows(IntPtr.Zero);
            List<IntPtr> dsProcRootWindows = new List<IntPtr>();
            foreach (IntPtr hWnd in rootWindows)
            {
                uint lpdwProcessId;
                GetWindowThreadProcessId(hWnd, out lpdwProcessId);
                if (lpdwProcessId == pid)
                    dsProcRootWindows.Add(hWnd);
            }
            return dsProcRootWindows;
        }

        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                Win32Callback childProc = new Win32Callback(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }
    }


    public static class Globals
    {
        public static string pid = "";
        public static string process = "";
        public static Process proc = new Process();
        public static List<IntPtr> OldChildren = new List<IntPtr>();
        public static List<IntPtr> NewHandleChildren = new List<IntPtr>();
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        static extern int SendMessage3(IntPtr hwndControl, uint Msg, int wParam, StringBuilder strBuffer); // get text
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        static extern int SendMessage4(IntPtr hwndControl, uint Msg, int wParam, int lParam);  // text length
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTxt(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        public const UInt32 WM_CLOSE = 0x0010;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x0202;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const uint WM_CHAR = 0x102;
        //public const int BM_SETSTATE



        public static string GetTextBoxText(IntPtr hTextBox)
        {
            uint WM_GETTEXT = 0x000D;
            int len = GetTextBoxTextLength(hTextBox);
            if (len <= 0) return null;  // no text
            StringBuilder sb = new StringBuilder(len + 1);
            SendMessage3(hTextBox, WM_GETTEXT, len + 1, sb);
            return sb.ToString();
        }

        static int GetTextBoxTextLength(IntPtr hTextBox)
        {
            // helper for GetTextBoxText
            uint WM_GETTEXTLENGTH = 0x000E;
            int result = SendMessage4(hTextBox, WM_GETTEXTLENGTH, 0, 0);
            return result;
        }

        public static void Click(IntPtr hTextBox)
        {
            SendMessage(hTextBox, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);   //send left button mouse down
            SendMessage(hTextBox, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);     //send left button mouse up
        // SendMessage(hTextBox, BM_SETSTATE, IntPtr., IntPtr.Zero);     //send change state
        }

        public static void SendText(IntPtr hTextBox,string text)
        {
            int data = Convert.ToInt32(text);
            SendMessage(hTextBox, WM_KEYDOWN, (IntPtr)data, IntPtr.Zero);
            //SendMessage(hTextBox, WM_CHAR, (int)Keys.R, 0);
            SendMessage(hTextBox, WM_KEYUP, IntPtr.Zero, IntPtr.Zero);
        }
    }

}
