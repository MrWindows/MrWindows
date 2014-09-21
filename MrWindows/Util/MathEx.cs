using System;
using System.Drawing;

namespace MrWindows.Util {
    public static class MathEx {
        public static Point CalcMiddle(Point a, Point b) {
            return new Point((a.X + b.X)/2, (a.Y + b.Y)/2);
        }

        public static double CalcDistance(Point a, Point b) {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
    }
}