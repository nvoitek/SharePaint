import { Coord2D } from "./Coord2D"
import { ShapeType } from "./ShapeType"

export interface Shape {
    id?: string,
    shapeType: ShapeType,
    author: string,
    points: Coord2D[]
}