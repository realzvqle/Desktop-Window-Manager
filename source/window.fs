module window

open types
open virtdesktop


open Raylib_cs


let setupWindow : windowData =
    let data: windowData = {winHeight=900;winWidth=1600;winName="Window-Manager"}

    data



let createWindow =
    let mutable globData: globalData = {currentScene=0;};
    let data: windowData = setupWindow
    Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
    Raylib.InitWindow(data.winWidth, data.winHeight, data.winName);
    while not (Raylib.WindowShouldClose()) do
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        virtDesktopManager globData
        // Raylib.DrawFPS(10, 10)
        Raylib.EndDrawing();
