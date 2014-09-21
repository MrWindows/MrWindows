using System.Runtime.InteropServices;

namespace MrWindows {
    public static class WindowsPInvoke {
        [DllImport("user32")]
        public static extern void LockWorkStation();
    }
}