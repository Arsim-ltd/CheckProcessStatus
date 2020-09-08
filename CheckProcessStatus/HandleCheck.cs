using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CheckProcessStatus;
using System.Windows.Forms;

namespace CheckProcessStatus
{
    class HandleCheck
    {
        public static void StartHandleCheck()
        {
            List<IntPtr> children = HandlesStuff.GetHandle(Globals.pid);
            
            if (Globals.OldChildren.Count != children.Count || Program.form1.NewHandlesOnlyBox.Checked == false)
            {
                WriteToLog.Logger("Old Handle Count:" + Globals.OldChildren.Count + Environment.NewLine + "New Handle Count: " + children.Count);
                if (Globals.OldChildren.Count > 0 || Program.form1.NewHandlesOnlyBox.Checked == true)
                {
                    if (Program.form1.NewHandlesOnlyBox.Checked == false) { Globals.OldChildren.Clear(); }
                    IEnumerable<IntPtr> differenceQuery = children.Except(Globals.OldChildren);

                    foreach (IntPtr NewHandle in differenceQuery)
                    {
                        string caption = Globals.GetTextBoxText(NewHandle);
                        string SubCaption = "SubHandles:" + Environment.NewLine;

                        //Get all child handles of new handle
                        //if (caption == "Address Bar")
                        //{
                        try
                        {
                                Globals.NewHandleChildren = HandlesStuff.GetChildWindows(NewHandle);
                        }
                        catch (Exception Ex)
                        {
                                WriteToLog.Logger("Problem: " + Ex.Message);
                        }
                        //}

                        //Show all child handles of new handle
                        foreach (IntPtr subhandle in Globals.NewHandleChildren)
                        {
                            string HandleText = Globals.GetTextBoxText(subhandle);

                            if (HandleText != null)
                            {
                                SubCaption += HandleText + Environment.NewLine;
                            }

                        }

                        WriteToLog.Logger("New Handle Title:" + caption + Environment.NewLine + "Handle ID:" + NewHandle.ToString() +
                        Environment.NewLine + Environment.NewLine + SubCaption);
                        
                        //Close New Handles
                        if (Program.form1.AutoCloseHandlesBox.Checked == true)
                            
                        {
                            Globals.SendMessage(NewHandle, Globals.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                        }

                    }
                }

                Globals.OldChildren.Clear();               
                Globals.OldChildren.AddRange(children);
            }
            else
            {
                WriteToLog.Logger("Handle Count: " + children.Count);
                Globals.OldChildren.Clear();
                Globals.OldChildren.AddRange(children);
            }
            children = null;
            GC.Collect(3);
        }

        public static void NewHandleCheck()
        {
            List<IntPtr> children = HandlesStuff.GetHandle(Globals.pid);

            foreach (IntPtr NewHandle in children)
            {
                string caption = Globals.GetTextBoxText(NewHandle);
                //We are looking for Mail window. If it's not found, disregard and assume profile already exists.
                if (caption == "Mail")
                {
                    WriteToLog.Logger("Mail window Found. Checking Subhandles." + Environment.NewLine);
                    
                    try
                    {
                        List<IntPtr> SubChildren1 = HandlesStuff.GetChildWindows(NewHandle);
                        //Show all child handles of new handle
                        foreach (IntPtr subhandle in SubChildren1)
                        {
                            string HandleText = Globals.GetTextBoxText(subhandle);

                            if (HandleText != null)
                            {
                                if (HandleText == "A&dd...")
                                {
                                    WriteToLog.Logger("Subwindow Add... found." + Environment.NewLine);
                                    Globals.Click(subhandle);
                                    List<IntPtr> NewChildren = HandlesStuff.GetHandle(Globals.pid);
                                    IEnumerable<IntPtr> differenceQuery = NewChildren.Except(children);
                                    foreach (IntPtr sh in NewChildren)
                                    {
                                        string sht = Globals.GetTextBoxText(sh);
                                        WriteToLog.Logger("New Handle " + sht);
                                        //SendText
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        WriteToLog.Logger("Problem: " + Ex.Message);
                    }

                }
                else
                {
                    //WriteToLog.Logger("caption is " + caption + Environment.NewLine);
                }
            }

            children = null;
            GC.Collect(3);

        }
    }

}