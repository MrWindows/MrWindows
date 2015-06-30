using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dear.MouseControl;

namespace Dear.Screens {
    public class ScreenInfo : IScreen {

        private Mouse _mouse = new Mouse();

        public Size MainScreenSize {
            get {
                return new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            }
        }

        public Size GetActiveScreenSize() {
            var point = _mouse.CursorLocation;
            int screenWidth = Screen.FromPoint(point).Bounds.Width;
            int screenHeight = Screen.FromPoint(point).Bounds.Height;
            return new Size(screenWidth, screenHeight);
        }
    }
}
