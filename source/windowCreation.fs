module windowCreation


open types
open buttons

open Raylib_cs

let spawnWindow (window: zivWindow) (titleBarColor: Color) (windowColor: Color) 
                (textColor: Color) (titleBarTitle: string) (isResizeAble: bool) =
                if window.init = false then
                    window.prevSizeX <- window.sizeX
                    window.prevSizeY <- window.sizeY
                    window.init <- true
                drawButton "" window.x window.y window.sizeX window.sizeY None windowColor textColor windowColor (Raylib.GetFontDefault())
                let bar: buttonState = drawButton titleBarTitle window.x (window.y-30) window.sizeX 30 None titleBarColor textColor titleBarColor (Raylib.GetFontDefault())
                if bar = BUTTON_DOWN_LEFT || window.isDragging then
                    if window.isDragging = false then
                        window.isDragging <- true
                        window.dragOffsetX <- Raylib.GetMouseX() - window.x
                        window.dragOffsetY <- Raylib.GetMouseY() - window.y
                    else if window.isDragging && (Raylib.IsMouseButtonDown(MouseButton.Left)) then
                        window.x <- Raylib.GetMouseX() - window.dragOffsetX
                        window.y <- Raylib.GetMouseY() - window.dragOffsetY
                        window.dragStopDelay <- window.dragStopDelay - (float)(Raylib.GetFrameTime());
                if Raylib.IsMouseButtonReleased(MouseButton.Left) || (window.isDragging && window.dragStopDelay <= 0) then
                    window.isDragging <- false
                    window.dragStopDelay <- 0.5