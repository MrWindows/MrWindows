using System;
using System.Threading;

namespace MrWindows.KeyboardControl {
    public class Keyboard {
        public void ReleaseKey(VirtualKey key) {
            KeyboardPInvoke.keybd_event((byte) key, 0x45, 0x1 | 0x2, (UIntPtr) 0);
        }

        public void PressKey(VirtualKey key) {
            KeyboardPInvoke.keybd_event((byte) key, 0x45, 0x1, (UIntPtr) 0);
        }

        public void TypeKey(VirtualKey key, int delay = 0) {
            PressKey(key);
            if (delay > 0) {
                Thread.Sleep(delay);                
            }
            ReleaseKey(key);
        }
    }
}