module virtdesktop

open types
open buttons
open mainDesktop


open Raylib_cs


let virtDesktopManager (data: globalData) =
    match data.currentScene with
    | 0 -> 
        mainDesktopScene data
        1
    | 1 -> Raylib.DrawText("It Changed :shock:", 12, 12, 80, Color.Green);
           1
    | _ -> Raylib.DrawText("Invalid Scene", 12, 12, 60, Color.Red)
           1