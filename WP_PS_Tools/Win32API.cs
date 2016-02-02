using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using System.Diagnostics;

namespace WP_PS_Tools
{
    public static class Win32API
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo,
           bool fAttach);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(int uiAction, uint uiParam, ref uint pvParam, int fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool LockSetForegroundWindow(uint uLockCode);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern bool AllowSetForegroundWindow(int dwProcessId);


        public static void ForceWindowIntoForeground(IntPtr window)
        {
            uint currentThread = GetCurrentThreadId();
            // get the current thread and active window thread
            // and attach them if they are not the same
            IntPtr activeWindow = GetForegroundWindow();
            uint activeProcess;
            uint activeThread = GetWindowThreadProcessId(activeWindow, out activeProcess);
            Process proc = Process.GetProcessById((int)activeProcess);
            string name = proc.MainWindowTitle;
            uint windowProcess;
            uint windowThread = GetWindowThreadProcessId(window, out windowProcess);
            Process proc2 = Process.GetProcessById((int)windowProcess);
            string name2 = proc2.MainWindowTitle;
            if (currentThread != activeThread)
                AttachThreadInput(currentThread, activeThread, true);
            if (windowThread != currentThread)
                AttachThreadInput(windowThread, currentThread, true);


            // unlock the timer disallowing setforeground window
            uint oldTimeout = 0, newTimeout = 0;
            SystemParametersInfo(0x2000, 0, ref oldTimeout, 0);  //SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000,
            SystemParametersInfo(0x2001, 0, ref newTimeout, 0);  // public const uint SPI_SETFOREGROUNDLOCKTIMEOUT = 0x2001;
            LockSetForegroundWindow(2);                          //static readonly uint LSFW_LOCK = 1;
            //static readonly uint LSFW_UNLOCK = 2;
            AllowSetForegroundWindow(-1);                        // ASFW_ANY = -1 

            // bring WP window to the foreground
            SetForegroundWindow(window);
            ShowWindow(window, 5);     //currentstate = 5
            //SetFocus(window);

            //restore lockout timer to default setting
            SystemParametersInfo(0x2001, 0, ref oldTimeout, 0);

            //attach current thread to WP instance
            if (currentThread != activeThread)
                AttachThreadInput(currentThread, activeThread, false);
            if (windowThread != currentThread)
                AttachThreadInput(windowThread, currentThread, false);

        }


    }
}
