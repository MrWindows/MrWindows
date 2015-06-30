using Dear.KeyboardControl;
using Dear.MediaControl;
using Dear.MouseControl;
using Dear.Screens;
using Dear.Tasks;
using Dear.WindowControl;

namespace Dear {
    public class MrWindows {
        public IMouse Mouse { get; set; }
        public IKeyboard Keyboard { get; set; }
        public IWindow CurrentWindow { get; set; }
        public IMedia Media { get; set; }
        public IScreen Screen { get; set; }
        public ITaskManager TaskManager { get; set; }

        public MrWindows() {
            Mouse = new Mouse();    
            Keyboard = new Keyboard();
            CurrentWindow = new Window();
            Media = new Media();
            Screen = new ScreenInfo();
            TaskManager = new TaskManager();
        }

        public void LockWorkStation() {
            WindowsPInvoke.LockWorkStation();
        }
    }
}