import { ShapeType } from "./ShapeType";

export enum Mode {
    SelectPoint,
    SelectArea,
    DrawTriangle,
    DrawRectangle,
    DrawCircle
}

export function isDrawMode(mode: Mode) {
    if (mode === Mode.DrawTriangle || mode === Mode.DrawRectangle || mode === Mode.DrawCircle) {
        return true;
    } else {
        return false;
    }
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