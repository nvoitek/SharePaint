import './Toolbar.css';

export function Toolbar() {

    return (
        <div className="toolbar">
            <button className="toolbar-triangle">Select</button>
            <button className="toolbar-triangle">Select Area</button>
            <button className="toolbar-triangle">Triangle</button>
            <button className="toolbar-triangle">Rectangle</button>
            <button className="toolbar-triangle">Circle</button>
        </div>
    );
}