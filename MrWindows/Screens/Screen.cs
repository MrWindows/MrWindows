using Dear.MouseControl;
using System.Drawing;
using System.Windows.Forms;

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

        public void TurnOff() {
            SetMonitorState(MonitorState.MonitorStateOff);
        }

        public void TurnOn() {
            SetMonitorState(MonitorState.MonitorStateOn);
        }

        public void StandBy() {
            SetMonitorState(MonitorState.MonitorStateStandBy);
        }

        private void SetMonitorState(MonitorState state) {
            ScreenPInvoke.SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }
    }
}
