import { Coord2D } from "../models/Coord2D";
import { ShapeType } from "../models/ShapeType";

export function checkIfComplete(points: Coord2D[], shapeType: ShapeType) : boolean {
    if ((shapeType === ShapeType.Triangle && points.length === 3)
        || (shapeType === ShapeType.Rectangle && points.length === 2)
        || (shapeType === ShapeType.Circle && points.length === 2)) {
            return true;
        }

    return false;
}

export function drawOnCanvas(context: CanvasRenderingContext2D, points: Coord2D[], shapeType: ShapeType, color: string) {
    if (shapeType === ShapeType.Triangle) {
        drawTriangle(context, points, color);
    } else if (shapeType === ShapeType.Rectangle) {
        drawRectangle(context, points, color);
    } else if (shapeType === ShapeType.Circle) {
        drawCircle(context, points, color);
    }
}

function drawTriangle(context: CanvasRenderingContext2D, points: Coord2D[], color: string) {
    if (points.length !== 3) {
        return;
    }

    context.strokeStyle = color;

    context.beginPath();
    context.moveTo(points[0].x, points[0].y);

    context.lineTo(points[1].x, points[1].y);
    context.stroke();
    
    context.lineTo(points[2].x, points[2].y);
    context.stroke();

    context.lineTo(points[0].x, points[0].y);
    context.stroke();
}

function drawRectangle(context: CanvasRenderingContext2D, points: Coord2D[], color: string) {
    if (points.length !== 2) {
        return;
    }
    
    context.strokeStyle = color;

    context.beginPath();
    context.moveTo(points[0].x, points[0].y);

    context.lineTo(points[0].x, points[1].y);
    context.stroke();
    
    context.lineTo(points[1].x, points[1].y);
    context.stroke();

    context.lineTo(points[1].x, points[0].y);
    context.stroke();
    
    context.lineTo(points[0].x, points[0].y);
    context.stroke();
}

function drawCircle(context: CanvasRenderingContext2D, points: Coord2D[], color: string) {
    if (points.length !== 2) {
        return;
    }
    
    context.strokeStyle = color;

    let radius = Math.sqrt(Math.pow(points[0].x - points[1].x, 2) + Math.pow(points[0].y - points[1].y, 2));

    context.beginPath();
    context.arc(points[0].x, points[0].y, radius, 0, 2 * Math.PI);
    context.stroke();
}