namespace MrWindows.KeyboardControl {
    public interface IKeyboard {
        Keyboard Press(params VirtualKey[] keys);
        Keyboard Release(params VirtualKey[] keys);
        Keyboard Type(params VirtualKey[] keys);
        Keyboard Wait(int milliseconds);
    }
}