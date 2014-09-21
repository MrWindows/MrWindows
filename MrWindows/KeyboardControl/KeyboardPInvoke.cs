using System;
using System.Runtime.InteropServices;

namespace MrWindows.KeyboardControl {
    public static class KeyboardPInvoke {
        [DllImport("user32.dll")]
        public static extern short GetKeyState(VirtualKey key);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    }
}