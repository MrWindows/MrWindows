using System.Drawing;

namespace MrWindows.MouseControl {
    public interface IMouse {
        Point CursorLocation { get; }
        void SetCursorPosition(int x, int y);
        void SetCursorPosition(Point point);
        void MoveCursor(int left, int top);
        void MouseLeftClick();
        void MouseRightClick();
        void MouseMiddleClick();
        void MouseLeftDown();
        void MouseLeftUp();
        bool IsMouseLeftUp();
        bool IsMouseLeftDown();
        void ScrollVertically(int units);
        void ScrollHorizontally(int units);
    }
}