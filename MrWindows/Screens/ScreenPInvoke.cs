using System.Runtime.InteropServices;

namespace Dear.Screens {
    public static class ScreenPInvoke {
        
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
    }

    public enum MonitorState {
        MonitorStateOn = -1,
        MonitorStateOff = 2,
        MonitorStateStandBy = 1
    }
}
