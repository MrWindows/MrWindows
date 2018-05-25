using Dear.MouseControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using static Dear.Screens.ScreenPInvoke;

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

        public void SetGamma(int gamma) {
            if(gamma > 256) {
                gamma = 256;
            }
            if(gamma < 1) {
                gamma = 1;
            }
            var ramp = new RAMP {
                Green = new ushort[256],
                Blue = new ushort[256],
                Red = new ushort[256]
            };
            for (var i = 1; i < 256; i++) {
                var iArrayValue = i * (gamma + 128);
                if (iArrayValue > 65535) {
                    iArrayValue = 65535;
                }
                ramp.Red[i] = ramp.Blue[i] = ramp.Green[i] = (ushort)iArrayValue;
            }
            SetDeviceGammaRamp(GetDC(IntPtr.Zero), ref ramp);
        }

        private void SetMonitorState(MonitorState state) {
            ScreenPInvoke.SendMessage(0xFFFF, 0x112, 0xF170, (int)state);
        }
    }
}
