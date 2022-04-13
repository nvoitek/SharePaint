import './Canvas.scss';
import React, { useState, useRef, useEffect } from 'react';
import { drawOnCanvas, checkIfComplete } from '../../utils/draw';
import axios from 'axios';
import { Shape } from '../../models/Shape';
import { Coord2D } from '../../models/Coord2D';
import { Mode, isDrawMode, getShapeType } from '../../models/Mode';
import iwanthue from 'iwanthue';

interface CanvasProps {
    currentMode: Mode
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
            // TODO: Decide whether to use int or double in the model
            x: Math.round(event.clientX - canvas.getBoundingClientRect().x),
            y: Math.round(event.clientY - canvas.getBoundingClientRect().y)
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
            drawOnCanvas(ctx, newDrawingPoints, shapeType, "black")

            axios
                .post("/api/shapes", {
                    author: 'test',
                    shapeType: getShapeType(props.currentMode),
                    points: newDrawingPoints
                })
                .then(res => console.log(res));

            setIsDrawing(false);
            setDrawingPoints([]);

        } else {
            setDrawingPoints(newDrawingPoints);
        }
    }

    const select = () => {

    }

    useEffect(() => {
        if (!canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        axios
            .get("/api/shapes")
            .then(res => {
                let authors: any[] = [];
                for (let item of res.data) {
                    if (!authors.find(x => x.author === item.author)) {
                        authors.push({
                            author: item.author,
                            id: authors.length
                        });
                    }
                }

                let palette = iwanthue(authors.length);
                
                for (let item of res.data) {
                    let shape = item as Shape;

                    let color = palette[authors.find(x => x.author === item.author).id];

                    drawOnCanvas(ctx!, shape.points, shape.shapeType, color);
                }
            });

    }, [canvasRef])

    return (
        <canvas
            ref={canvasRef}
            // TODO calculate canvas size based on available space
            width={1200} height={800}
            className={`canvas ${(isDrawMode(props.currentMode)) ? 'draw-cursor' : ''}`}
            onClick={onClick}
        >
            Your browser does not support the canvas element.
        </canvas>
    );
}