using System;
using MrWindows;

namespace Playground {
    class Program {
        static void Main(string[] args) {
            var win = new Windows();
            while (true) {
                Console.WriteLine("Volume: ");
                Console.ReadLine();
                win.Media.VolumeUp();
            }
        }
    }
}
