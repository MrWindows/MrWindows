using System.Runtime.InteropServices;

namespace Dear {
    public static class WindowsPInvoke {
        [DllImport("user32")]
        public static extern void LockWorkStation();
    }
}