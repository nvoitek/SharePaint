import './App.scss';
import { useEffect, useState } from 'react';
import { Toolbar } from './components/toolbar/Toolbar';
import { Canvas } from './components/canvas/Canvas';
import { Mode } from './models/Mode';
import { Legend } from './components/legend/Legend';
import { Shape } from './models/Shape';
import { getShapes } from './services/ShapeService';
import iwanthue from 'iwanthue';

function App() {

  const [mode, setMode] = useState<Mode>(Mode.SelectPoint);
  const [usersColorsMap, setUsersColorsMap] = useState<{ [user: string]: string }>({});
  const [shapes, setShapes] = useState<Shape[]>([]);

  useEffect(() => {
    getShapes()
      .then(shapes => {
        // NOT PART OF MVP : different colors for different users
        // TODO: Optimize double iteration
        let newUsersColorsMap: { [user: string]: string } = {};
        for (let shape of shapes) {
          if (!(shape.author in newUsersColorsMap)) {
            newUsersColorsMap[shape.author] = "";
          }
        }

        let palette: string[] = [];
        if (Object.keys(newUsersColorsMap).length <= 2) {
          palette = ["red", "blue"];
        } else {
          palette = iwanthue(Object.keys(newUsersColorsMap).length);
        }

        for (let i = 0; i < palette.length; i++) {
          newUsersColorsMap[Object.keys(newUsersColorsMap)[i]] = palette[i];
        }

        setUsersColorsMap(newUsersColorsMap);
        setShapes(shapes);
      })
      .catch(err => console.log(err));
  }, []);

  return (
    <div className="App">
      <Toolbar currentMode={mode} setMode={setMode} />
      <Canvas currentMode={mode} usersColorsMap={usersColorsMap} shapes={shapes}/>
      <Legend usersColorsMap={usersColorsMap} />
    </div>
  );
}

export default App;
