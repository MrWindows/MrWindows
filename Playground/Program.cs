using System;
using System.Threading;
using Dear;
using Dear.KeyboardControl;

namespace Playground {
    class Program {
        static void Main(string[] args) {
            var win = new MrWindows();
            var k = win.Keyboard;

            Action hadouken = () => {
                k.Press(VirtualKey.Down).Wait(200);
                k.Press(VirtualKey.Right).Wait(10);
                k.Release(VirtualKey.Down);
                k.Press(VirtualKey.D).Wait(100);
                k.Release(VirtualKey.Right);
                k.Release(VirtualKey.D);
                Console.WriteLine("----------------------------------> hadouken!");
                Console.WriteLine("----------------------------------> hadouken!");
                Console.WriteLine("----------------------------------> hadouken!");
                Console.WriteLine("----------------------------------> hadouken!");
                Console.WriteLine("----------------------------------> hadouken!");
            };

            hadouken.Invoke();
        }
    }
}
