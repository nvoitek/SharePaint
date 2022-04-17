import './Canvas.scss';
import React, { useState, useRef, useEffect } from 'react';
import { drawOnCanvas, checkIfComplete, normalizePoints } from '../../utils/draw';
import { Shape } from '../../models/Shape';
import { Coord2D } from '../../models/Coord2D';
import { Mode, isDrawMode, getShapeType, isSelectMode } from '../../models/Mode';
import { createShape, getShapesInsideArea, getShapesUnderPoint } from '../../services/ShapeService';
import { toast } from 'react-toastify';
import { Area2D } from '../../models/Area2D';

interface CanvasProps {
    currentMode: Mode,
    usersColorsMap: { [user: string]: string },
    shapes: Shape[],
    onSelectLoading?: (isLoading: boolean) => void,
    onSelect?: (selectedShapes: Shape[]) => void,
    // TODO calculate canvas size
    canvasWidth: number,
    canvasHeight: number
    widthProportion: number,
    heightProportion: number,
}

export function Canvas(props: CanvasProps) {

    const canvasRef = useRef<HTMLCanvasElement>(null);
    const [inProgress, setInProgress] = useState<boolean>(false);
    const [clickedPoints, setClickedPoints] = useState<Coord2D[]>([]);

    const onClick = (event: React.MouseEvent<HTMLElement>) => {
        if (isDrawMode(props.currentMode)) {
            draw(event);
        } else if (isSelectMode(props.currentMode)) {
            select(event);
        }
    }

    const handleKeyboardEvent = (e: React.KeyboardEvent<HTMLImageElement>) => {
        if (e.code === "Escape") {
            reset();
        }
    };

    const getClickCoord2D = (canvas: HTMLCanvasElement, event: React.MouseEvent<HTMLElement>): Coord2D => {
        return {
            x: event.clientX - canvas.getBoundingClientRect().x,
            y: event.clientY - canvas.getBoundingClientRect().y
        };
    }

    const reset = () => {
        setInProgress(false);
        setClickedPoints([]);
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
        let newClickedPoints = [...clickedPoints, clickPoint];
        let shapeType = getShapeType(props.currentMode);

        if (!inProgress) {
            setInProgress(true);
            setClickedPoints(newClickedPoints);

        } else if (checkIfComplete(newClickedPoints, shapeType)) {

            drawOnCanvas(ctx, normalizePoints(newClickedPoints, props.widthProportion, props.heightProportion), shapeType, "black")

            let shape: Shape = {
                author: 'test',
                shapeType: getShapeType(props.currentMode),
                points: newClickedPoints
            }

            createShape(shape)
                .then(id => console.log(id))
                .catch(err => {
                    console.log(err)
                    toast.error("Failed getting shapes", {})
                });

            reset();

        } else {
            setClickedPoints(newClickedPoints);
        }
    }

    const select = (event: React.MouseEvent<HTMLElement>) => {
        if (!canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        let clickPoint = getClickCoord2D(canvasRef.current, event);
        let newClickedPoints = [...clickedPoints, clickPoint];

        if (!inProgress) {

            if (props.currentMode === Mode.SelectPoint) {
                props.onSelectLoading?.(true);
                getShapesUnderPoint(newClickedPoints[0])
                    .then(res => {
                        props.onSelectLoading?.(false);
                        return props.onSelect?.(res);
                    })
                    .catch(err => {
                        console.log(err)
                        toast.error("Failed getting shapes", {})
                    });
            } else {
                setInProgress(true);
                setClickedPoints(newClickedPoints);
            }
        } else {

            let area: Area2D = {
                point1: newClickedPoints[0],
                point2: newClickedPoints[1]
            }

            props.onSelectLoading?.(true);
            getShapesInsideArea(area)
                .then(res => {
                    props.onSelectLoading?.(false);
                    return props.onSelect?.(res);
                })
                .catch(err => {
                    console.log(err)
                    toast.error("Failed getting shapes", {})
                });

            reset();
        }
    }

    useEffect(() => {
        reset();
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

    }, [canvasRef, props.usersColorsMap, props.shapes, props.widthProportion, props.heightProportion])

    return (
        <div className='canvas-container' onKeyDown={handleKeyboardEvent} tabIndex={0}>
            <canvas
                ref={canvasRef}
                width={props.canvasWidth} height={props.canvasHeight}
                className={`canvas ${(isDrawMode(props.currentMode)) ? 'draw-cursor' : ''}`}
                onClick={onClick}
            >
                Your browser does not support the canvas element.
            </canvas>
        </div>
    );
}