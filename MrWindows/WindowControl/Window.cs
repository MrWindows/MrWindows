using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MrWindows.WindowControl {
    public class Window {
        public string GetTitle() {
            return GetForegroundProcess().MainWindowTitle;
        }

        private static Process GetForegroundProcess() {
            var id = WindowPInvoke.GetForegroundWindow();
            int processId;
            WindowPInvoke.GetWindowThreadProcessId(id, out processId);
            Process foregroundProcess = Process.GetProcessById(processId);
            return foregroundProcess;
        }

        public string GetProcessName() {
            return GetForegroundProcess().ProcessName;            
        }
    }

    public static class WindowPInvoke {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr windowHandle, out int processId);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, StringBuilder text, int count);
    }
}
