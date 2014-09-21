using System.Runtime.InteropServices;
using MrWindows.KeyboardControl;

namespace MrWindows.MouseControl {
    public static class MousePInvoke {
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(VirtualKey key);
    }
}