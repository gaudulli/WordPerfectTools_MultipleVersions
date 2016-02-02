using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;



using PerfectScriptFactory;
using GenericPS;



namespace WP_PS_Tools
{
    public class WP_Window
    {

        public GenericPerfectScript PSContainer { get; set; }
        public dynamic PS { get; set; }
        public IntPtr parentHandle { get; set; }
        public IntPtr wpHandle { get; set; }

        string _fileName;
        public int WPVersion;
        string WPWin;


        /**
         * Initialize perfect script object
         */
        public WP_Window(IntPtr parentHandle, bool newProcess = false, string fileName = "")
        {
            _fileName = fileName;
            this.parentHandle = parentHandle;
            initWordPerfectHandle(newProcess);
        }



        /**
         * Get the window handle for the word perfect process
         */
        private void initWordPerfectHandle(bool newProcess = false)
        {
            WPVersion = FileUtilities.getWPVersion();
            WPWin = "wpwin" + WPVersion.ToString();
            Process WPProcess = getLatestWPInstance(); // check to see if WP running

            if (newProcess || WPProcess == null)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = WPWin;
                proc.StartInfo.Arguments = _fileName;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                Thread.Sleep(2000);     // wait for WP process to finish starting before accessing PerfectScript
            }
            if (WPVersion != 0)
            {
                PSContainer = MakePerfectScriptObject.getPS(WPVersion);
                PS = PSContainer.perfectScript;

            }

            initPerfectScript();
            wpHandle = getLatestWPInstance().MainWindowHandle;
            setParent();
            PS.WPActivate();
            PS.AppMaximize();

            if (!newProcess)
            {
                releaseScript();
            }
        }



        private Process getLatestWPInstance()
        {
            Process[] p = Process.GetProcessesByName(WPWin);
            if (p.Length > 0)
            {
                //get the most recent wpwin process

                List<DateTime> startTime = new List<DateTime>();
                foreach (Process x in p)
                {
                    startTime.Add(x.StartTime);
                }
                return p[startTime.IndexOf(startTime.Max())];
            }
            else return null;
        }


        /**
         * Set the parent of the word perfect window
         * This allows the word perfect window to be embeded inside the form
         */
        public void setParent()
        {
            Win32API.SetParent(wpHandle, parentHandle);

        }


        public void initPerfectScript()
        {
            if (PS == null)
            {
                PSContainer = MakePerfectScriptObject.getPS(PSContainer.version);
                PS = PSContainer.perfectScript;
            }
        }




        /**
         * Cleanup of perfect script object
         */
        public void releaseScript()
        {
            Win32API.ForceWindowIntoForeground(wpHandle);   // hack to force the WP cursor to be present and blinking where desired.
            if (PS == null)
            {
                initPerfectScript();    // it seems silly to create PS just to destroy it, but this is just in 
                // case PS is already null, but for some reason has not been released as a COM object
            }
            PS.WPActivate();
            Marshal.ReleaseComObject(PS);
            PS = null;


        }


        /**
         * Exit the word perfect window/process
         */
        public void exit(bool exitWP = false)
        {
            releaseScript();
            parentHandle = new IntPtr(0);
            setParent();    // set parentHandle to 0, which will releses the wpwin handle from the form.
            if (exitWP)
            {
                Process p = getLatestWPInstance();
                p.Kill();
            }

        }




    }

}
