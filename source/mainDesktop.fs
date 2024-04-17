module mainDesktop

open types
open buttons
open windowCreation

open Raylib_cs

let window: zivWindow = {x=100;y=100;sizeX=1200;sizeY=500;prevSizeX=0;prevSizeY=0;isDragging=false;
                        dragOffsetX=0;dragOffsetY=0;dragStopDelay=0;isResizing=false;resizeOffsetX=0;
                        resizeOffsetY=0;resizeButtonHeight=0;resizeButtonGap=0;resizeStopDelay=0;init=false}

let secondWindow: zivWindow = {x=400;y=400;sizeX=1200;sizeY=300;prevSizeX=0;prevSizeY=0;isDragging=false;
                        dragOffsetX=0;dragOffsetY=0;dragStopDelay=0;isResizing=false;resizeOffsetX=0;
                        resizeOffsetY=0;resizeButtonHeight=0;resizeButtonGap=0;resizeStopDelay=0;init=false}

let mainDesktopScene (data: globalData) =
    spawnWindow window Color.Blue Color.Red Color.White "Stuff" false
    drawButton "Hello" (window.x + 30) (window.y + 30) 300 90 (Some 40) Color.Gray Color.Black Color.DarkGray (Raylib.GetFontDefault())
    spawnWindow secondWindow Color.Violet Color.Green Color.White "Ather" false
