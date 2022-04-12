import './Canvas.scss';
import React, {useState, useRef} from 'react';
import { Mode } from '../toolbar/Toolbar';

interface CanvasProps {
    currentMode: Mode
}

export function Canvas(props: CanvasProps) {

    const canvasRef = useRef<HTMLCanvasElement>(null);
    const [isDrawing, setIsDrawing] = useState<boolean>(false);
    const [startPoint, setStartPoint] = useState<[number, number]>([0,0]);
    const [pointsNr, setPointsNr] = useState<number>(0);
    const [context, setContext] = useState<CanvasRenderingContext2D | null>(null);


    const modeIsDraw = () => {
        if (props.currentMode===Mode.DrawTriangle || props.currentMode===Mode.DrawRectangle || props.currentMode===Mode.DrawCircle) {
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

    const draw = (event: React.MouseEvent<HTMLElement>) => {
        if (!canvasRef || !canvasRef.current) {
            return;
        }
        
        if (!isDrawing) {
            let ctx = canvasRef.current.getContext("2d");
            if (ctx) {
                ctx.beginPath();
                ctx.moveTo(0, 0);
                ctx.moveTo(event.clientX - canvasRef.current.getBoundingClientRect().x, event.clientY - canvasRef.current.getBoundingClientRect().y);
                setContext(ctx);
                setIsDrawing(true);
                setPointsNr(1);
                setStartPoint([event.clientX - canvasRef.current.getBoundingClientRect().x, event.clientY - canvasRef.current.getBoundingClientRect().y]);
            }
        } else {
            context?.lineTo(event.clientX - canvasRef.current.getBoundingClientRect().x, event.clientY - canvasRef.current.getBoundingClientRect().y);
            context?.stroke();

            let newPointsNr = pointsNr + 1;
            setPointsNr(newPointsNr);

            // TODO better handling for other shapes, create more functions
            if (newPointsNr === 3 && props.currentMode === Mode.DrawTriangle) {
                context?.lineTo(startPoint[0], startPoint[1]);
                context?.stroke();

                setIsDrawing(false);
                setPointsNr(0);
            }
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