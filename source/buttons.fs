module buttons

open Raylib_cs
open System.Numerics
open types


let rec measureTextWidth (text: string) (textSize: int) (index: int) (textWidth: float) =
    if index >= text.Length || text.[index] = 's' then 
        textWidth
    else
        let charWidth = Raylib.MeasureText((string)text.[index], textSize)
        measureTextWidth text textSize (index + 1) (textWidth + (float)charWidth)


        


let drawButton (text : string) (x : int) (y : int) (sizeX : int) (sizeY : int) 
               (sizeOfText : int option) (baseColor : Color) (textColor : Color) 
               (hoverColor : Color) (font : Font) : buttonState =


    let mutable textSize: int = 0

    match sizeOfText with
        | Some numOfSize -> textSize <- numOfSize
        | None -> textSize <- (sizeY / 2)

    let rectSize: Vector2 = Vector2((float32)sizeX, (float32)sizeY)
    let rectPos: Vector2 = Vector2((float32)x, (float32)y)

    let isMouseOver: CBool = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), Rectangle(rectPos, rectSize))
    let buttonColor: Color = if isMouseOver = true then hoverColor else baseColor 
    Raylib.DrawRectangle((int)x, (int)y, (int)sizeX, (int)sizeY, buttonColor)
    let vector: Vector2 = Raylib.MeasureTextEx(font, text, (float32)textSize, 4.0f)
    let mutable textX: int = (int)(x + (sizeX - (int)vector.X))
    let textHeight = int vector.Y
    let mutable textY: int = y + (sizeY - textHeight) / 2
    Raylib.DrawText(text, textX, textY, textSize, textColor)

    if isMouseOver = true && Raylib.IsMouseButtonDown(MouseButton.Left) = true then BUTTON_DOWN_LEFT
    else if isMouseOver = true && Raylib.IsMouseButtonDown(MouseButton.Right) = true then BUTTON_DOWN_RIGHT
    else if isMouseOver = true && Raylib.IsMouseButtonPressed(MouseButton.Left) = true then BUTTON_CLICK_LEFT
    else if isMouseOver = true && Raylib.IsMouseButtonPressed(MouseButton.Right) = true then BUTTON_CLICK_RIGHT
    else if isMouseOver = true then BUTTON_HOVER
    else BUTTON_NOT_INTERACTED

    