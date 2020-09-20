using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProcessMash.Tools
{
    public class Window
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public static string GetActiveProcessFileName()
        {
            GetWindowThreadProcessId(GetForegroundWindow(), out var pid);

            return Process.GetProcessById((int)pid).ProcessName;
        }
    }
}
