module types


type windowData = {
    winWidth: int;
    winHeight: int;
    winName: string
};

type globalData = {
    mutable currentScene: int
}

type buttonState =
    | BUTTON_NOT_INTERACTED
    | BUTTON_HOVER
    | BUTTON_CLICK_LEFT
    | BUTTON_CLICK_RIGHT
    | BUTTON_DOWN_LEFT
    | BUTTON_DOWN_RIGHT


type zivWindow = {
    mutable x: int;
    mutable y: int;
    mutable sizeX: int;
    mutable sizeY: int;
    mutable prevSizeX: int;
    mutable prevSizeY: int;
    mutable isDragging: bool;
    mutable dragOffsetX: int;
    mutable dragOffsetY: int;
    mutable dragStopDelay: float;
    mutable isResizing: bool;
    mutable resizeOffsetX: int;
    mutable resizeOffsetY: int;
    mutable resizeButtonHeight: int;
    mutable resizeButtonGap: int;
    mutable resizeStopDelay: int;
    mutable init: bool
}