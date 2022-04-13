import { Mode } from '../../models/Mode';
import './Toolbar.scss';

interface ToolbarProps {
    currentMode: Mode,
    setMode: (mode: Mode) => void;
}

export function Toolbar(props: ToolbarProps) {

    const onChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        props.setMode(Number.parseInt(event.target.value));
    }

    return (
        <div className="toolbar" onChange={onChange}>
            <label>
                <input className="toolbar-select-point" name="toolbar-radio" type="radio" value={Mode.SelectPoint} defaultChecked={props.currentMode === Mode.SelectPoint} />
                Select
            </label>

            <label>
                <input className="toolbar-select-area" name="toolbar-radio" type="radio" value={Mode.SelectArea} defaultChecked={props.currentMode === Mode.SelectArea} />
                Select Area
            </label>

            <label>
                <input className="toolbar-draw-triangle" name="toolbar-radio" type="radio" value={Mode.DrawTriangle} defaultChecked={props.currentMode === Mode.DrawTriangle} />
                Triangle
            </label>

            <label>
                <input className="toolbar-draw-rectangle" name="toolbar-radio" type="radio" value={Mode.DrawRectangle} defaultChecked={props.currentMode === Mode.DrawRectangle} />
                Rectangle
            </label>

            <label>
                <input className="toolbar-draw-circle" name="toolbar-radio" type="radio" value={Mode.DrawCircle} defaultChecked={props.currentMode === Mode.DrawCircle} />
                Circle
            </label>
        </div>
    );
}