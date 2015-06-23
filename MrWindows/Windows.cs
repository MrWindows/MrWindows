using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using MrWindows.KeyboardControl;
using MrWindows.MediaControl;
using MrWindows.MouseControl;
using MrWindows.WindowControl;

namespace MrWindows {
    public class Windows {
        public IMouse Mouse { get; set; }
        public IKeyboard Keyboard { get; set; }
        public IWindow CurrentWindow { get; set; }
        public IMedia Media { get; set; }

        public Windows() {
            Mouse = new Mouse();    
            Keyboard = new Keyboard();
            CurrentWindow = new Window();
            Media = new Media();
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

        public Process OpenApp(string key) {
            return Process.Start(key);
        }

        public Process GoogleThis(string query) {
            return Process.Start("http://google.com/search?q=" + query);
        }
    }
}