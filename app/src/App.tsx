import './App.scss';
import React, {useState} from 'react';
import { Toolbar } from './components/toolbar/Toolbar';
import { Canvas } from './components/canvas/Canvas';
import { Mode } from './models/Mode';

function App() {

  const [mode, setMode] = useState<Mode>(Mode.SelectPoint);

  return (
    <div className="App">
      <Toolbar currentMode={mode} setMode={setMode}/>
      <Canvas currentMode={mode}/>
    </div>
  );
}

export default App;
