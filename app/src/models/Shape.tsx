import { Coord2D } from "./Coord2D"
import { ShapeType } from "./ShapeType"

export interface Shape {
    shapeType: ShapeType,
    author: string,
    points: Coord2D[]
}