using System;
using System.Threading;
using Dear;

namespace Playground {
    class Program {
        static void Main(string[] args) {
            var win = new MrWindows();

            win.Screen.StandBy();

            Thread.Sleep(2000);

            win.Screen.TurnOn();

        }
    }
}
