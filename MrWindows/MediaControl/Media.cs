using Dear.KeyboardControl;

namespace Dear.MediaControl {
    public class Media : IMedia {
        public void VolumeUp() {
            new Keyboard().Type(VirtualKey.VolumeUp);
        }

        public void VolumeDown() {
            new Keyboard().Type(VirtualKey.VolumeDown);
        }

        public void VolumeMute() {
            new Keyboard().Type(VirtualKey.VolumeMute);
        }
    }
}