<p align="center">
  <img src="https://raw.githubusercontent.com/MrWindows/MrWindows/master/Assets/MrWindows_horizontal.png" width="350px" alt="Mr. Windows" />
</p>
Tell MrWindows to do anything for you. A.K.A. P/Invoke like a boss :)

---
### Nuget: Instal-Package MrWindows
---

## Create our butler

var win = new Dear.MrWindows();

## Interact with the Mouse
```
var cursorLocation = win.Mouse.CursorLocation;
win.Mouse.MouseLeftClick();
win.Mouse.ScrollHorizontally(10);
win.Mouse.MoveCursor(x, y);
```

## Interact with the Keyboard
```
win.Keyboard.Type(VirtualKey.A).Type(VirtualKey.Return);
win.Keyboard.Press(VirtualKey.Up).Wait(10).Release(VirtualKey.Up);
```
## Interact with Media
```
win.Media.VolumeUp();
win.Media.VolumeMute();
```

## Interact with the TaskManager
```
var processes = win.TaskManager.ListAllProcesses();
win.TaskManager.GoogleThis("asdf");
win.TaskManager.OpenApp("some app");
```

## Interact with the Screen
```
var mainScreenSize = win.Screen.MainScreenSize;
var currentScreenSize = win.Screen.GetActiveScreenSize();
```
