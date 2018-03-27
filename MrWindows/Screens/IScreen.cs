using System.Drawing;

namespace Dear.Screens {
    public interface IScreen {
        Size MainScreenSize { get; }
        Size GetActiveScreenSize();

        void TurnOff();
        void TurnOn();
        void StandBy();
    }
}