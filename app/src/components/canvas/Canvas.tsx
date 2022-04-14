import './Canvas.scss';
import React, { useState, useRef, useEffect } from 'react';
import { drawOnCanvas, checkIfComplete } from '../../utils/draw';
import { Shape } from '../../models/Shape';
import { Coord2D } from '../../models/Coord2D';
import { Mode, isDrawMode, getShapeType } from '../../models/Mode';
import iwanthue from 'iwanthue';
import { createShape, getShapes } from '../../services/ShapeService';

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

            let shape: Shape = {
                author: 'test',
                shapeType: getShapeType(props.currentMode),
                points: newDrawingPoints
            }

            createShape(shape).then(id => console.log(id)).catch(err => console.log(err));

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

        getShapes()
            .then(shapes => {
                // NOT PART OF MVP : different colors for different users
                // TODO: Optimize double iteration
                let authors: any[] = [];
                for (let shape of shapes) {
                    if (!authors.find(x => x.author === shape.author)) {
                        authors.push({
                            author: shape.author,
                            id: authors.length
                        });
                    }
                }

                let palette: string[] = [];
                if (authors.length <= 2) {
                    palette = ["red", "blue"];
                } else {
                    palette = iwanthue(authors.length);
                }

                for (let shape of shapes) {
                    let color = palette[authors.find(x => x.author === shape.author).id];

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