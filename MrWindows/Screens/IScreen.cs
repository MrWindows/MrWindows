using System.Drawing;

namespace Dear.Screens {
    public interface IScreen {
        Size MainScreenSize { get; }
        Size GetActiveScreenSize();

        void TurnOff();
        void TurnOn();
        void StandBy();
        /// <summary>
        /// Changes screen gamma values.
        /// </summary>
        /// <param name="gamma">0 to 100</param>
        void SetGamma(int gamma);
    }
}