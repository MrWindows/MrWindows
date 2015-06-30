using System.Drawing;

namespace Dear.Screens {
    public interface IScreen {
        Size MainScreenSize { get; }
        Size GetActiveScreenSize();
    }
}