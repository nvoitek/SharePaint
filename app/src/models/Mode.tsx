import { ShapeType } from "./ShapeType";

export enum Mode {
    None,
    SelectPoint,
    SelectArea,
    DrawTriangle,
    DrawRectangle,
    DrawCircle
}

export function isDrawMode(mode: Mode) {
    return (mode === Mode.DrawTriangle || mode === Mode.DrawRectangle || mode === Mode.DrawCircle);
}

export function isSelectMode(mode: Mode) {
    return (mode === Mode.SelectPoint || mode === Mode.SelectArea);
}

export function getShapeType(mode: Mode) : ShapeType {
    if (mode === Mode.DrawTriangle) {
        return ShapeType.Triangle
    } else if (mode === Mode.DrawRectangle) {
        return ShapeType.Rectangle
    } else if (mode === Mode.DrawCircle) {
        return ShapeType.Circle
    } else {
        return ShapeType.Unknown;
    }
}