import ContentLoader from 'react-content-loader';
import { Mode } from '../../models/Mode';
import { Shape } from '../../models/Shape';
import { Canvas } from '../canvas/Canvas';
import './Preview.scss';

interface PreviewProps {
    usersColorsMap: { [user: string]: string },
    shapes: Shape[],
    isPreviewLoading: boolean,
    // TODO calculate canvas size
    canvasWidth: number,
    canvasHeight: number,
    previewWidth: number,
    previewHeight: number
}

export function Preview(props: PreviewProps) {


    return (
        <div className='preview'>
            {
                (props.shapes.length === 0)
                    ? ''
                    : (props.isPreviewLoading)
                        ? <div className='preview-scrollable'>
                            <ContentLoader className='row loader'/>
                            <ContentLoader className='row loader'/>
                            <ContentLoader className='row loader'/>
                        </div>
                        : <div className='preview-scrollable'>
                            {
                                props.shapes.map((x: Shape, i: number) => {
                                    return (
                                        <div className='row' key={i}>
                                            <p>{x.author}</p>
                                            {/* This canvas has to be normalized knowing the big canvas width/height and the small canvas width/height */}
                                            <Canvas currentMode={Mode.None} usersColorsMap={props.usersColorsMap} shapes={[x]} canvasWidth={props.previewWidth} canvasHeight={props.previewHeight} widthProportion={props.previewWidth / props.canvasWidth} heightProportion={props.previewHeight / props.canvasHeight} />
                                        </div>
                                    )
                                })
                            }
                        </div>

            }
        </div>
    );
}