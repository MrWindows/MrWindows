using System;
using System.Threading;

namespace Dear.KeyboardControl {
    public class Keyboard : IKeyboard {
        public Keyboard Press(params VirtualKey[] keys) {
            foreach (var key in keys) {
                var flag = key.IsExtendedKey() ? KeyboardFlag.ExtendedKey : 0;
                var scan = KeyboardPInvoke.MapVirtualKey((uint)key, 0) & 0xFFU;
                KeyboardPInvoke.keybd_event((byte)key, (byte)scan, (uint)flag, (UIntPtr)0);
            }
            return this;
        }

        public Keyboard Release(params VirtualKey[] keys) {
            foreach (var key in keys) {
                var flag = key.IsExtendedKey() ? KeyboardFlag.ExtendedKey | KeyboardFlag.KeyUp : KeyboardFlag.KeyUp;
                var scan = KeyboardPInvoke.MapVirtualKey((uint)key, 0) & 0xFFU;
                KeyboardPInvoke.keybd_event((byte)key, (byte)scan, (uint)flag, (UIntPtr)0);
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