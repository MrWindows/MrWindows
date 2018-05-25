using System;
using System.Threading;
using Dear;

namespace Playground {
    class Program {
        static void Main(string[] args) {
            var win = new MrWindows();
            //win.Screen.StandBy();
            win.Screen.SetGamma(50);
            Thread.Sleep(100);
            //win.Screen.TurnOn();

        }
    }
}
