using System;
using System.Threading;

namespace MrWindows.KeyboardControl {
    public class Keyboard {
        public Keyboard Press(params VirtualKey[] keys) {
            foreach (var key in keys) {
                KeyboardPInvoke.keybd_event((byte)key, VirtualKeyBreak.GetBreak(key), 0x1, (UIntPtr)0);
            }
            return this;
        }

        public Keyboard Release(params VirtualKey[] keys) {
            foreach (var key in keys) {
                KeyboardPInvoke.keybd_event((byte)key, VirtualKeyBreak.GetBreak(key), 0x1 | 0x2, (UIntPtr)0);
            }
            return this;
        }

        public Keyboard Type(params VirtualKey[] keys) {
            Press(keys);                
            Release(keys);
            return this;
        }

        public Keyboard Wait(int milliseconds) {
            Thread.Sleep(milliseconds);
            return this;
        }
    }

    public static class VirtualKeyBreak {
        public static byte GetBreak(VirtualKey key) {
            if (key == VirtualKey.Alt) {
                return 0xb8;
            }
            return 0x45;
        }
    }
}