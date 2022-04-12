import React from 'react';
import './App.css';
import { Toolbar } from './components/toolbar/Toolbar';
import { Canvas } from './components/canvas/Canvas';

function App() {

  return (
    <div className="App">
      <Toolbar />
      <Canvas />
    </div>
  );
}

export default App;
