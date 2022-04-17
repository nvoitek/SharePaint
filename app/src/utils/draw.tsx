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

export function drawShape(context: CanvasRenderingContext2D, points: Coord2D[], shapeType: ShapeType, color: string) {
    if (shapeType === ShapeType.Triangle) {
        drawTriangle(context, points, color);
    } else if (shapeType === ShapeType.Rectangle) {
        drawRectangle(context, points, color);
    } else if (shapeType === ShapeType.Circle) {
        drawCircle(context, points, color);
    }
}

export function previewSelect(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length !== 2) {
        return;
    }

    context.setLineDash([6]);
    context.strokeRect(points[0].x, points[0].y, points[1].x - points[0].x, points[1].y - points[0].y);
}

export function previewShape(context: CanvasRenderingContext2D, points: Coord2D[], shapeType: ShapeType) {
    if (shapeType === ShapeType.Triangle) {
        previewTriangle(context, points);
    } else if (shapeType === ShapeType.Rectangle) {
        previewRectangle(context, points);
    } else if (shapeType === ShapeType.Circle) {
        previewCircle(context, points);
    }
}

export function clear(context: CanvasRenderingContext2D, canvasWidth: number, canvasHeight: number) {
    context.clearRect(0, 0, canvasWidth, canvasHeight);
}

export function normalizePoints(points: Coord2D[], widthProportion: number, heightProportion: number) : Coord2D[] {
    if (widthProportion === 1 && heightProportion === 1) {
        return points;
    }

    let normalizedPoints: Coord2D[] = [];

    for (let i = 0; i < points.length; i++) {
        let newX = heightProportion * points[i].x;
        let newY = widthProportion * points[i].y;

        normalizedPoints.push({x: newX, y:newY});
    }

    return normalizedPoints;
}

function drawTriangle(context: CanvasRenderingContext2D, points: Coord2D[], color: string) {
    if (points.length !== 3) {
        return;
    }

    context.strokeStyle = color;

    context.beginPath();
    context.moveTo(points[0].x, points[0].y);
    context.lineTo(points[1].x, points[1].y);
    context.lineTo(points[2].x, points[2].y);
    context.lineTo(points[0].x, points[0].y);
    context.stroke();
}

function previewTriangle(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length === 2) {
        context.beginPath();
        context.moveTo(points[0].x, points[0].y);
        context.lineTo(points[1].x, points[1].y);
        context.stroke();
    } else if (points.length === 3){
        context.beginPath();
        context.moveTo(points[0].x, points[0].y);
        context.lineTo(points[1].x, points[1].y);
        context.lineTo(points[2].x, points[2].y);
        context.lineTo(points[0].x, points[0].y);
        context.stroke();
    }
}

function drawRectangle(context: CanvasRenderingContext2D, points: Coord2D[], color: string) {
    if (points.length !== 2) {
        return;
    }
    
    context.strokeStyle = color;

    context.strokeRect(points[0].x, points[0].y, points[1].x - points[0].x, points[1].y - points[0].y);
}

function previewRectangle(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length !== 2) {
        return;
    }

    context.strokeRect(points[0].x, points[0].y, points[1].x - points[0].x, points[1].y - points[0].y);
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

function previewCircle(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length !== 2) {
        return;
    }

    let radius = Math.sqrt(Math.pow(points[0].x - points[1].x, 2) + Math.pow(points[0].y - points[1].y, 2));

    context.beginPath();
    context.arc(points[0].x, points[0].y, radius, 0, 2 * Math.PI);
    context.stroke();
}