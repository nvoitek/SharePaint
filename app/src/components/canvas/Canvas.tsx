import './Canvas.scss';
import React, { useState, useRef } from 'react';
import { Mode } from '../toolbar/Toolbar';
import { drawOnCanvas, Coord2D, checkIfComplete } from '../../utils/draw';

interface CanvasProps {
    currentMode: Mode
}

export function Canvas(props: CanvasProps) {

    const canvasRef = useRef<HTMLCanvasElement>(null);
    const [isDrawing, setIsDrawing] = useState<boolean>(false);
    const [drawingPoints, setDrawingPoints] = useState<Coord2D[]>([]);
    // const [context, setContext] = useState<CanvasRenderingContext2D | null>(null);


    const modeIsDraw = () => {
        if (props.currentMode === Mode.DrawTriangle || props.currentMode === Mode.DrawRectangle || props.currentMode === Mode.DrawCircle) {
            return true;
        } else {
            return false;
        }
    }

    const onClick = (event: React.MouseEvent<HTMLElement>) => {
        if (modeIsDraw()) {
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

        if (!isDrawing) {
            setIsDrawing(true);
            setDrawingPoints(newDrawingPoints);

        } else if (checkIfComplete(newDrawingPoints, props.currentMode)) {
            drawOnCanvas(ctx, newDrawingPoints, props.currentMode)
            setIsDrawing(false);
            setDrawingPoints([]);

        } else {
            setDrawingPoints(newDrawingPoints);
        }
    }

    const select = () => {

    }

    return (
        <canvas
            ref={canvasRef}
            // TODO calculate canvas size based on available space
            width={1200} height={800}
            className={`canvas ${(modeIsDraw()) ? 'draw-cursor' : ''}`}
            onClick={onClick}
        >
            Your browser does not support the canvas element.
        </canvas>
    );
}