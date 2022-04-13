import { Mode } from "../components/toolbar/Toolbar";

export interface Coord2D {
    x: number,
    y: number
}

export function checkIfComplete(points: Coord2D[], mode: Mode) : boolean {
    if ((mode === Mode.DrawTriangle && points.length === 3)
        || (mode === Mode.DrawRectangle && points.length === 2)
        || (mode === Mode.DrawCircle && points.length === 2)) {
            return true;
        }

    return false;
}

export function drawOnCanvas(context: CanvasRenderingContext2D, points: Coord2D[], mode: Mode) {
    if (mode === Mode.DrawTriangle) {
        drawTriangle(context, points);
    } else if (mode === Mode.DrawRectangle) {
        drawRectangle(context, points);
    } else if (mode === Mode.DrawCircle) {
        drawCircle(context, points);
    }
}

function drawTriangle(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length !== 3) {
        return;
    }

    context.beginPath();
    context.moveTo(points[0].x, points[0].y);

    context.lineTo(points[1].x, points[1].y);
    context.stroke();
    
    context.lineTo(points[2].x, points[2].y);
    context.stroke();

    context.lineTo(points[0].x, points[0].y);
    context.stroke();
}

function drawRectangle(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length !== 2) {
        return;
    }

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

function drawCircle(context: CanvasRenderingContext2D, points: Coord2D[]) {
    if (points.length !== 2) {
        return;
    }

    let radius = Math.sqrt(Math.pow(points[0].x - points[1].x, 2) + Math.pow(points[0].y - points[1].y, 2));

    context.beginPath();
    context.arc(points[0].x, points[0].y, radius, 0, 2 * Math.PI);
    context.stroke();
}