import './Canvas.scss';
import React, { useState, useRef, useEffect, useCallback } from 'react';
import { drawShape, checkIfComplete, normalizePoints, clear } from '../../utils/draw';
import { Shape } from '../../models/Shape';
import { Coord2D } from '../../models/Coord2D';
import { Mode, isDrawMode, getShapeType, isSelectMode } from '../../models/Mode';
import { createShape, getShapesInsideArea, getShapesUnderPoint } from '../../services/ShapeService';
import { toast } from 'react-toastify';
import { Area2D } from '../../models/Area2D';
import { ShapeType } from '../../models/ShapeType';

interface CanvasProps {
    user?: string,
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
    const previewCanvasRef = useRef<HTMLCanvasElement>(null);

    const [inProgress, setInProgress] = useState<boolean>(false);
    const [clickedPoints, setClickedPoints] = useState<Coord2D[]>([]);

    const onClick = (event: React.MouseEvent<HTMLElement>) => {
        if (isDrawMode(props.currentMode)) {
            draw(event);
        } else if (isSelectMode(props.currentMode)) {
            select(event);
        }
    }

    const onMove = (event: React.MouseEvent<HTMLElement>) => {
        if (isDrawMode(props.currentMode)) {
            drawPreview(event);
        } else if (isSelectMode(props.currentMode)) {
            selectPreview(event);
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

    const reset = useCallback(() => {
        setInProgress(false);
        setClickedPoints([]);

        if (!previewCanvasRef || !previewCanvasRef.current) {
            return;
        }

        let previewCtx = previewCanvasRef.current.getContext("2d");

        if (!previewCtx) {
            return;
        }

        clear(previewCtx, props.canvasWidth, props.canvasHeight);
    },[props.canvasWidth, props.canvasHeight]);

    const draw = (event: React.MouseEvent<HTMLElement>) => {
        if (!previewCanvasRef || !previewCanvasRef.current || !canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        let clickPoint = getClickCoord2D(previewCanvasRef.current, event);
        let newClickedPoints = [...clickedPoints, clickPoint];
        let shapeType = getShapeType(props.currentMode);

        if (!inProgress) {
            // first click
            setInProgress(true);
            setClickedPoints(newClickedPoints);

        } else if (checkIfComplete(newClickedPoints, shapeType)) {
            // last click
            drawShape(ctx, normalizePoints(newClickedPoints, props.widthProportion, props.heightProportion), shapeType)

            if (props.user) {
                let shape: Shape = {
                    author: props.user,
                    shapeType: getShapeType(props.currentMode),
                    points: newClickedPoints
                }
    
                createShape(shape)
                    .then(id => console.log(id))
                    .catch(err => {
                        console.log(err)
                        toast.error("Failed getting shapes", {})
                    });
            }

            reset();

        } else {
            // every other click
            setClickedPoints(newClickedPoints);
        }
    }

    // http://jsfiddle.net/ebeit303/kfhL0j83/
    const drawPreview = (event: React.MouseEvent<HTMLElement>) => {
        if (inProgress) {
            if (!previewCanvasRef || !previewCanvasRef.current || !canvasRef || !canvasRef.current) {
                return;
            }

            let previewCtx = previewCanvasRef.current.getContext("2d");

            if (!previewCtx) {
                return;
            }

            let currentPoint = getClickCoord2D(previewCanvasRef.current, event);
            clear(previewCtx, props.canvasWidth, props.canvasHeight);
            drawShape(previewCtx, [...clickedPoints, currentPoint], getShapeType(props.currentMode));
        }
    }

    const select = (event: React.MouseEvent<HTMLElement>) => {
        if (!previewCanvasRef || !previewCanvasRef.current || !canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        let clickPoint = getClickCoord2D(previewCanvasRef.current, event);
        let newClickedPoints = [...clickedPoints, clickPoint];

        if (!inProgress) {
            // first click
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
            // second click
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

    // http://jsfiddle.net/ebeit303/kfhL0j83/
    const selectPreview = (event: React.MouseEvent<HTMLElement>) => {
        if (inProgress) {
            if (!previewCanvasRef || !previewCanvasRef.current || !canvasRef || !canvasRef.current) {
                return;
            }

            let previewCtx = previewCanvasRef.current.getContext("2d");

            if (!previewCtx) {
                return;
            }

            let currentPoint = getClickCoord2D(previewCanvasRef.current, event);
            clear(previewCtx, props.canvasWidth, props.canvasHeight);
            drawShape(previewCtx, [...clickedPoints, currentPoint], ShapeType.Rectangle, "#282828", true);
        }
    }

    useEffect(() => {
        reset();
    }, [props.currentMode, reset]);

    useEffect(() => {
        if (!canvasRef || !canvasRef.current) {
            return;
        }

        let ctx = canvasRef.current.getContext("2d");

        if (!ctx) {
            return;
        }

        for (let shape of props.shapes) {
            drawShape(ctx!, normalizePoints(shape.points, props.widthProportion, props.heightProportion), shape.shapeType, props.usersColorsMap[shape.author]);
        }

    }, [canvasRef, props.usersColorsMap, props.shapes, props.widthProportion, props.heightProportion])

    return (
        <div className='canvas-container' onKeyDown={handleKeyboardEvent} tabIndex={0}>
            <canvas
                ref={canvasRef}
                width={props.canvasWidth} height={props.canvasHeight}
                className='main-canvas'
            >
                Your browser does not support the canvas element.
            </canvas>

            <canvas
                ref={previewCanvasRef}
                width={props.canvasWidth} height={props.canvasHeight}
                className={`preview-canvas ${(isDrawMode(props.currentMode)) ? 'draw-cursor' : ''}`}
                onClick={onClick}
                onMouseMove={onMove}
            />
        </div>
    );
}