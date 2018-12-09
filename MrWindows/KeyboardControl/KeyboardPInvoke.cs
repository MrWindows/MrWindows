using System;
using System.Runtime.InteropServices;

namespace Dear.KeyboardControl {
    public static class KeyboardPInvoke {
        [DllImport("user32.dll")]
        public static extern short GetKeyState(VirtualKey key);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        /// <summary>
        /// Used to find the keyboard input scan code for single key input. 
        /// Some applications do not receive the input when scan is not set.
        /// </summary>
        /// <param name="uCode"></param>
        /// <param name="uMapType"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);
    }
}