using System;
using System.Drawing;
using MrWindows.KeyboardControl;
using MrWindows.Util;

namespace MrWindows.MouseControl {
    public class Mouse : IMouse {
        public Point CursorLocation {
            get {
                POINT lpPoint;
                MousePInvoke.GetCursorPos(out lpPoint);
                return new Point(lpPoint.X, lpPoint.Y);
            }
        }

        public void SetCursorPosition(int left, int top) {
            MousePInvoke.SetCursorPos(left,top);
        }

        public void SetCursorPosition(Point p) {
            MousePInvoke.SetCursorPos(p.X, p.Y);
        }

        public void MoveCursor(int left, int top) {
            var actual = CursorLocation;
            var next = new Point(left, top);
            var m2 = MathEx.CalcMiddle(actual, next);
            var m1 = MathEx.CalcMiddle(actual, m2);
            var m3 = MathEx.CalcMiddle(m2, next);
            SetCursorPosition(m1);
            SetCursorPosition(m2);
            SetCursorPosition(m3);
            SetCursorPosition(next);
        }

        public void MouseLeftClick() {
            MousePInvoke.mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            MousePInvoke.mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public void MouseRightClick() {
            MousePInvoke.mouse_event((uint)MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            MousePInvoke.mouse_event((uint)MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
        }

        public void MouseMiddleClick() {
            MousePInvoke.mouse_event((uint)MouseEventFlags.MIDDLEDOWN, 0, 0, 0, 0);
            MousePInvoke.mouse_event((uint)MouseEventFlags.MIDDLEUP, 0, 0, 0, 0);
        }

        public void MouseLeftDown() {
            MousePInvoke.mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
        }

        public void MouseLeftUp() {
            MousePInvoke.mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public bool IsMouseLeftUp() {
            return !IsMouseLeftDown();
        }

        public bool IsMouseLeftDown() {
            return Convert.ToBoolean(MousePInvoke.GetKeyState(VirtualKey.VK_LBUTTON) & (int)KeyState.KeyPressed);
        }

        public void ScrollVertically(int units) {
            MousePInvoke.mouse_event((uint)MouseEventFlags.MOUSEEVENTF_WHEEL, 0, 0, (uint)units, 0);
        }

        public void ScrollHorizontally(int units) {
            var keyboard = new Keyboard();
            keyboard.PressKey(VirtualKey.VK_SHIFT);
            ScrollVertically(units);
            keyboard.ReleaseKey(VirtualKey.VK_SHIFT);
        }
    }
}