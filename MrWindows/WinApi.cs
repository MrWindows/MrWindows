using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MrWindows.KeyboardControl;

namespace Sense {
    public static class WinApi {

        [DllImport("user32")]
        public static extern void LockWorkStation();

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            out IntPtr phToken
            );
        public enum LogonType {
            /// <summary>
            /// This logon type is intended for users who will be interactively using the computer, such as a user being logged on  
            /// by a terminal server, remote shell, or similar process.
            /// This logon type has the additional expense of caching logon information for disconnected operations; 
            /// therefore, it is inappropriate for some client/server applications,
            /// such as a mail server.
            /// </summary>
            LOGON32_LOGON_INTERACTIVE = 2,

            /// <summary>
            /// This logon type is intended for high performance servers to authenticate plaintext passwords.

            /// The LogonUser function does not cache credentials for this logon type.
            /// </summary>
            LOGON32_LOGON_NETWORK = 3,

            /// <summary>
            /// This logon type is intended for batch servers, where processes may be executing on behalf of a user without 
            /// their direct intervention. This type is also for higher performance servers that process many plaintext
            /// authentication attempts at a time, such as mail or Web servers. 
            /// The LogonUser function does not cache credentials for this logon type.
            /// </summary>
            LOGON32_LOGON_BATCH = 4,

            /// <summary>
            /// Indicates a service-type logon. The account provided must have the service privilege enabled. 
            /// </summary>
            LOGON32_LOGON_SERVICE = 5,

            /// <summary>
            /// This logon type is for GINA DLLs that log on users who will be interactively using the computer. 
            /// This logon type can generate a unique audit record that shows when the workstation was unlocked. 
            /// </summary>
            LOGON32_LOGON_UNLOCK = 7,

            /// <summary>
            /// This logon type preserves the name and password in the authentication package, which allows the server to make 
            /// connections to other network servers while impersonating the client. A server can accept plaintext credentials 
            /// from a client, call LogonUser, verify that the user can access the system across the network, and still 
            /// communicate with other servers.
            /// NOTE: Windows NT:  This value is not supported. 
            /// </summary>
            LOGON32_LOGON_NETWORK_CLEARTEXT = 8,

            /// <summary>
            /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
            /// The new logon session has the same local identifier but uses different credentials for other network connections. 
            /// NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
            /// NOTE: Windows NT:  This value is not supported. 
            /// </summary>
            LOGON32_LOGON_NEW_CREDENTIALS = 9,
        }
        public enum LogonProvider {
            /// <summary>
            /// Use the standard logon provider for the system. 
            /// The default security provider is negotiate, unless you pass NULL for the domain name and the user name 
            /// is not in UPN format. In this case, the default provider is NTLM. 
            /// NOTE: Windows 2000/NT:   The default security provider is NTLM.
            /// </summary>
            LOGON32_PROVIDER_DEFAULT = 0,
            LOGON32_PROVIDER_WINNT35 = 1,
            LOGON32_PROVIDER_WINNT40 = 2,
            LOGON32_PROVIDER_WINNT50 = 3
        }
        [DllImport("advapi32.dll", SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle, int
           SECURITY_IMPERSONATION_LEVEL, out IntPtr DuplicateTokenHandle);
        public static void Logon() {
            const int LOGON32_LOGON_INTERACTIVE = 2;
            const int LOGON32_LOGON_NETWORK = 3;
            const int LOGON32_LOGON_BATCH = 4;
            const int LOGON32_LOGON_SERVICE = 5;
            const int LOGON32_LOGON_UNLOCK = 7;
            const int LOGON32_LOGON_NETWORK_CLEARTEXT = 8;
            const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
            
            const int LOGON32_PROVIDER_DEFAULT = 0;

            const int SecurityImpersonation = 2;
            
            IntPtr hToken;
            IntPtr hTokenDuplicate = new IntPtr();
            var x = LogonUser("andrecarlucci@hotmail.com", "", "66qmacmmpi$", LOGON32_LOGON_INTERACTIVE,
                LOGON32_PROVIDER_DEFAULT, out hToken);
            DuplicateToken(hToken, SecurityImpersonation, out hTokenDuplicate);
                    WindowsIdentity windowsIdentity = new WindowsIdentity(hTokenDuplicate);
                    WindowsImpersonationContext impersonationContext = windowsIdentity.Impersonate();
            //        // ...
            //        impersonationContext.Undo();
            //    }
            //}

            //if (hToken != IntPtr.Zero) CloseHandle(hToken);
            //if (hTokenDuplicate != IntPtr.Zero) CloseHandle(hTokenDuplicate);

        }

        public static void Logon2() {
        }
             

        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKey nVirtKey);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int SRCCOPY = 0x00CC0020;
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hObject, int nXDest, int
        nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int
        nYSrc, int dwRop);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int
        nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);



        public enum MsgType {
            SB_LINELEFT = 0,
            SB_LINERIGHT = 1,
            SB_PAGELEFT = 2, //same value as SB_PAGEUP
            SB_PAGERIGHT = 3, //same value as SB_PAGEDOWN
            SB_THUMBPOSITION = 4,
            SB_THUMBTRACK = 5,
            SB_LEFT = 6,
            SB_RIGHT = 7,
            SB_ENDSCROLL = 8,
            WM_HSCROLL = 0x00000114
        }

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, MsgType uMsg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, String lpszClass, String lpszWindow);


        public static void ScrollVertically(int units) {
            mouse_event((uint)MouseEventFlags.MOUSEEVENTF_WHEEL, 0, 0, (uint) units, 0);
        }

        public static void ScrollHorizontally(int units) {
            SendKeyboardEventDown(VirtualKey.VK_SHIFT);
            mouse_event((uint)MouseEventFlags.MOUSEEVENTF_WHEEL, 0, 0, (uint)units, 0);
            SendKeyboardEventUp(VirtualKey.VK_SHIFT);
        }

        [Flags]
        public enum MouseEventFlags {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            MOUSEEVENTF_WHEEL = 0x800

        }

        /// <summary>
        /// simulates a keypress, see http://msdn2.microsoft.com/en-us/library/system.windows.forms.sendkeys(VS.71).aspx
        /// no winapi but this works just fine for me
        /// </summary>
        /// <param name="keys">the keys to press</param>
        public static void ManagedSendKeys(string keys) {
            SendKeys.SendWait(keys);
        }

        /// <summary>
        /// checks if the correct window is active, then send keypress
        /// </summary>
        /// <param name="keys">keys to press</param>
        /// <param name="windowName">window to send the keys to</param>
        public static void ManagedSendKeys(string keys, string windowName) {
            if (WindowActive(windowName)) {
                ManagedSendKeys(keys);
            }
        }
        /// <summary>
        /// sends a keystring to a window
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="handle"></param>
        public static void ManagedSendKeys(string keys, IntPtr handle) {
            if (WindowActive(handle)) {
                ManagedSendKeys(keys);
            }
        }
        /// <summary>
        /// sends a key to a window, pressing the button for x seconds
        /// </summary>
        /// <param name="key"></param>
        /// <param name="windowHandler"></param>
        /// <param name="delay"></param>
        public static void SendKeyboardEvent(Keys key, int delay = 0) {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            // I had some Compile errors until I Casted the final 0 to UIntPtr like this...
            keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            Thread.Sleep(delay);
            keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
        }

        public static void SendKeyboardEventUp(VirtualKey key) {
            keybd_event((byte)key, 0x45, 0x1 | 0x2, (UIntPtr)0);
        }

        public static void SendKeyboardEventDown(VirtualKey key) {
            keybd_event((byte)key, 0x45, 0x1, (UIntPtr)0);
        }

        public static void MouseLeftClick() {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public static void MouseRightClick() {
            mouse_event((uint)MouseEventFlags.RIGHTDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.RIGHTUP, 0, 0, 0, 0);
        }

        public static void MouseMiddleClick() {
            mouse_event((uint)MouseEventFlags.MIDDLEDOWN, 0, 0, 0, 0);
            mouse_event((uint)MouseEventFlags.MIDDLEUP, 0, 0, 0, 0);
        }

        public static void MouseLeftDown() {
            mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
        }

        public static void MouseLeftUp() {
            mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, 0);
        }

        public static bool IsMouseLeftUp() {
            return !IsMouseLeftDown();
        }

        public static bool IsMouseLeftDown() {
            const int KEY_PRESSED = 0x8000;
            return Convert.ToBoolean(GetKeyState(VirtualKey.VK_LBUTTON) & KEY_PRESSED);
        }

        public static void MouseMove(int x, int y) {
            SetCursorPos(x, y);
        }
        
        public static Point GetCursorPosition() {
            POINT lpPoint;
            GetCursorPos(out lpPoint);
            //bool success = User32.GetCursorPos(out lpPoint);
            // if (!success)
            return lpPoint;
        }

      
        public static void WindowMove(int x, int y, string windowName, int width, int height) {
            IntPtr window = FindWindow(null, windowName);
            if (window != IntPtr.Zero)
                MoveWindow(window, x, y, width, height, true);
        }

        public static void WindowMove(int x, int y, string windowName) {
            WindowMove(x, y, windowName, 800, 600);
        }

        public static bool WindowActive(string windowName) {
            IntPtr myHandle = FindWindow(null, windowName);
            IntPtr foreGround = GetForegroundWindow();
            if (myHandle != foreGround)
                return false;
            else
                return true;
        }
       
        public static bool WindowActive(IntPtr myHandle) {
            IntPtr foreGround = GetForegroundWindow();
            return myHandle == foreGround;
        }

        public static void WindowActivate(string windowName) {
            IntPtr myHandle = FindWindow(null, windowName);
            SetForegroundWindow(myHandle);
        }
        
        public static void WindowActivate(IntPtr handle) {
            SetForegroundWindow(handle);
        }

        public static Bitmap CreateScreenshot() {
            IntPtr hWnd = GetDesktopWindow();
            IntPtr hSorceDC = GetWindowDC(hWnd);
            RECT rect = new RECT();
            GetWindowRect(hWnd, ref rect);
            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;
            IntPtr hDestDC = CreateCompatibleDC(hSorceDC);
            IntPtr hBitmap = CreateCompatibleBitmap(hSorceDC, width, height);
            IntPtr hObject = SelectObject(hDestDC, hBitmap);
            BitBlt(hDestDC, 0, 0, width, height, hSorceDC, 0, 0, SRCCOPY);
            SelectObject(hDestDC, hObject);
            DeleteDC(hDestDC);
            ReleaseDC(hWnd, hSorceDC);
            Bitmap screenshot = Bitmap.FromHbitmap(hBitmap);
            DeleteObject(hBitmap);
            return screenshot;
        }


    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point) {
            return new Point(point.X, point.Y);
        }
    }

    public enum SystemMetric {
        SM_CXSCREEN = 0,  // 0x00
        SM_CYSCREEN = 1,  // 0x01
        SM_CXVSCROLL = 2,  // 0x02
        SM_CYHSCROLL = 3,  // 0x03
        SM_CYCAPTION = 4,  // 0x04
        SM_CXBORDER = 5,  // 0x05
        SM_CYBORDER = 6,  // 0x06
        SM_CXDLGFRAME = 7,  // 0x07
        SM_CXFIXEDFRAME = 7,  // 0x07
        SM_CYDLGFRAME = 8,  // 0x08
        SM_CYFIXEDFRAME = 8,  // 0x08
        SM_CYVTHUMB = 9,  // 0x09
        SM_CXHTHUMB = 10, // 0x0A
        SM_CXICON = 11, // 0x0B
        SM_CYICON = 12, // 0x0C
        SM_CXCURSOR = 13, // 0x0D
        SM_CYCURSOR = 14, // 0x0E
        SM_CYMENU = 15, // 0x0F
        SM_CXFULLSCREEN = 16, // 0x10
        SM_CYFULLSCREEN = 17, // 0x11
        SM_CYKANJIWINDOW = 18, // 0x12
        SM_MOUSEPRESENT = 19, // 0x13
        SM_CYVSCROLL = 20, // 0x14
        SM_CXHSCROLL = 21, // 0x15
        SM_DEBUG = 22, // 0x16
        SM_SWAPBUTTON = 23, // 0x17
        SM_CXMIN = 28, // 0x1C
        SM_CYMIN = 29, // 0x1D
        SM_CXSIZE = 30, // 0x1E
        SM_CYSIZE = 31, // 0x1F
        SM_CXSIZEFRAME = 32, // 0x20
        SM_CXFRAME = 32, // 0x20
        SM_CYSIZEFRAME = 33, // 0x21
        SM_CYFRAME = 33, // 0x21
        SM_CXMINTRACK = 34, // 0x22
        SM_CYMINTRACK = 35, // 0x23
        SM_CXDOUBLECLK = 36, // 0x24
        SM_CYDOUBLECLK = 37, // 0x25
        SM_CXICONSPACING = 38, // 0x26
        SM_CYICONSPACING = 39, // 0x27
        SM_MENUDROPALIGNMENT = 40, // 0x28
        SM_PENWINDOWS = 41, // 0x29
        SM_DBCSENABLED = 42, // 0x2A
        SM_CMOUSEBUTTONS = 43, // 0x2B
        SM_SECURE = 44, // 0x2C
        SM_CXEDGE = 45, // 0x2D
        SM_CYEDGE = 46, // 0x2E
        SM_CXMINSPACING = 47, // 0x2F
        SM_CYMINSPACING = 48, // 0x30
        SM_CXSMICON = 49, // 0x31
        SM_CYSMICON = 50, // 0x32
        SM_CYSMCAPTION = 51, // 0x33
        SM_CXSMSIZE = 52, // 0x34
        SM_CYSMSIZE = 53, // 0x35
        SM_CXMENUSIZE = 54, // 0x36
        SM_CYMENUSIZE = 55, // 0x37
        SM_ARRANGE = 56, // 0x38
        SM_CXMINIMIZED = 57, // 0x39
        SM_CYMINIMIZED = 58, // 0x3A
        SM_CXMAXTRACK = 59, // 0x3B
        SM_CYMAXTRACK = 60, // 0x3C
        SM_CXMAXIMIZED = 61, // 0x3D
        SM_CYMAXIMIZED = 62, // 0x3E
        SM_NETWORK = 63, // 0x3F
        SM_CLEANBOOT = 67, // 0x43
        SM_CXDRAG = 68, // 0x44
        SM_CYDRAG = 69, // 0x45
        SM_SHOWSOUNDS = 70, // 0x46
        SM_CXMENUCHECK = 71, // 0x47
        SM_CYMENUCHECK = 72, // 0x48
        SM_SLOWMACHINE = 73, // 0x49
        SM_MIDEASTENABLED = 74, // 0x4A
        SM_MOUSEWHEELPRESENT = 75, // 0x4B
        SM_XVIRTUALSCREEN = 76, // 0x4C
        SM_YVIRTUALSCREEN = 77, // 0x4D
        SM_CXVIRTUALSCREEN = 78, // 0x4E
        SM_CYVIRTUALSCREEN = 79, // 0x4F
        SM_CMONITORS = 80, // 0x50
        SM_SAMEDISPLAYFORMAT = 81, // 0x51
        SM_IMMENABLED = 82, // 0x52
        SM_CXFOCUSBORDER = 83, // 0x53
        SM_CYFOCUSBORDER = 84, // 0x54
        SM_TABLETPC = 86, // 0x56
        SM_MEDIACENTER = 87, // 0x57
        SM_STARTER = 88, // 0x58
        SM_SERVERR2 = 89, // 0x59
        SM_MOUSEHORIZONTALWHEELPRESENT = 91, // 0x5B
        SM_CXPADDEDBORDER = 92, // 0x5C
        SM_DIGITIZER = 94, // 0x5E
        SM_MAXIMUMTOUCHES = 95, // 0x5F

        SM_REMOTESESSION = 0x1000, // 0x1000
        SM_SHUTTINGDOWN = 0x2000, // 0x2000
        SM_REMOTECONTROL = 0x2001, // 0x2001

        SM_CONVERTABLESLATEMODE = 0x2003,
        SM_SYSTEMDOCKED = 0x2004,
    }


}
