using System.Diagnostics;

namespace MrWindows.WindowControl {
    public interface IWindow {
        string GetTitle();
        Process GetForegroundProcess();
        string GetProcessName();
    }
}