using System.Drawing;
using System.Windows.Forms;
using MrWindows.KeyboardControl;
using MrWindows.MouseControl;
using MrWindows.WindowControl;

namespace MrWindows {
    public class Windows {
        public Mouse Mouse { get; set; }
        public Keyboard Keyboard { get; set; }
        public Window CurrentWindow { get; set; }

        public Windows() {
            Mouse = new Mouse();    
            Keyboard = new Keyboard();
            CurrentWindow = new Window();
        }

        public void LockWorkStation() {
            WindowsPInvoke.LockWorkStation();
        }

        public Size MainScreenSize {
            get {
                return new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
        }

        public Size GetActiveScreenSize() {
            var point = Mouse.CursorLocation;
            int screenWidth = Screen.FromPoint(point).Bounds.Width;
            int screenHeight = Screen.FromPoint(point).Bounds.Height;
            return new Size(screenWidth, screenHeight);
        }
    }
}