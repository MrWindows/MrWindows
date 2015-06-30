using System.Diagnostics;

namespace Dear.WindowControl {
    public interface IWindow {
        string GetTitle();
        Process GetForegroundProcess();
        string GetProcessName();
    }
}