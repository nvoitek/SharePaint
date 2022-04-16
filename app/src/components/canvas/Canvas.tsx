import './Canvas.scss';
import React, { useState, useRef, useEffect } from 'react';
import { drawOnCanvas, checkIfComplete, normalizePoints } from '../../utils/draw';
import { Shape } from '../../models/Shape';
import { Coord2D } from '../../models/Coord2D';
import { Mode, isDrawMode, getShapeType } from '../../models/Mode';
import { createShape } from '../../services/ShapeService';
import { toast } from 'react-toastify';

interface CanvasProps {
    currentMode: Mode,
    usersColorsMap: { [user: string]: string },
    shapes: Shape[],
    // TODO calculate canvas size
    canvasWidth: number,
    canvasHeight: number
    widthProportion: number,
    heightProportion: number,
}

export function Canvas(props: CanvasProps) {

    const canvasRef = useRef<HTMLCanvasElement>(null);
    const [isDrawing, setIsDrawing] = useState<boolean>(false);
    const [drawingPoints, setDrawingPoints] = useState<Coord2D[]>([]);

    const onClick = (event: React.MouseEvent<HTMLElement>) => {
        if (isDrawMode(props.currentMode)) {
            draw(event);
        } else {
            select();
        }
    }

    const getClickCoord2D = (canvas: HTMLCanvasElement, event: React.MouseEvent<HTMLElement>): Coord2D => {
        return {
            x: event.clientX - canvas.getBoundingClientRect().x,
            y: event.clientY - canvas.getBoundingClientRect().y
        };
    }

    const draw = (event: React.MouseEvent<HTMLElement>) => {
        if (!canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        let clickPoint = getClickCoord2D(canvasRef.current, event);
        let newDrawingPoints = [...drawingPoints, clickPoint];
        let shapeType = getShapeType(props.currentMode);

        if (!isDrawing) {
            setIsDrawing(true);
            setDrawingPoints(newDrawingPoints);

        } else if (checkIfComplete(newDrawingPoints, shapeType)) {

            drawOnCanvas(ctx, normalizePoints(newDrawingPoints, props.widthProportion, props.heightProportion), shapeType, "black")

            let shape: Shape = {
                author: 'test',
                shapeType: getShapeType(props.currentMode),
                points: newDrawingPoints
            }

            createShape(shape)
                .then(id => console.log(id))
                .catch(err => {
                    console.log(err)
                    toast.error("Failed getting shapes", {})
                });

            setIsDrawing(false);
            setDrawingPoints([]);

        } else {
            setDrawingPoints(newDrawingPoints);
        }
    }

    const select = () => {

    }

    useEffect(() => {
        setIsDrawing(false);
        setDrawingPoints([]);
    }, [props.currentMode]);

    useEffect(() => {
        if (!canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        for (let shape of props.shapes) {
            drawOnCanvas(ctx!, normalizePoints(shape.points, props.widthProportion, props.heightProportion), shape.shapeType, props.usersColorsMap[shape.author]);
        }

    }, [canvasRef, props.usersColorsMap, props.shapes])

    return (
        <canvas
            ref={canvasRef}
            width={props.canvasWidth} height={props.canvasHeight}
            className={`canvas ${(isDrawMode(props.currentMode)) ? 'draw-cursor' : ''}`}
            onClick={onClick}
        >
            Your browser does not support the canvas element.
        </canvas>
    );
}