import './App.scss';
import { useEffect, useState } from 'react';
import { Toolbar } from './components/toolbar/Toolbar';
import { Canvas } from './components/canvas/Canvas';
import { Mode } from './models/Mode';
import { Legend } from './components/legend/Legend';
import { Shape } from './models/Shape';
import { getShapes } from './services/ShapeService';
import iwanthue from 'iwanthue';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import ContentLoader from 'react-content-loader';
import { Preview } from './components/preview/Preview';

function App() {

  const [mode, setMode] = useState<Mode>(Mode.SelectPoint);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [isPreviewLoading, setIsPreviewLoading] = useState<boolean>(false);
  const [usersColorsMap, setUsersColorsMap] = useState<{ [user: string]: string }>({});
  const [shapes, setShapes] = useState<Shape[]>([]);
  const [selectedShapes, setSelectedShapes] = useState<Shape[]>([]);

  // TODO calculate canvas size
  const canvasWidth = 1000;
  const canvasHeight = 800;
  const previewWidth = 200;
  const previewHeight = 160;

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
      .catch(err => {
        console.log(err)
        toast.error("Failed getting shapes", {})
      })
      .finally(()=> {
        setIsLoading(false);
      });
  }, []);

  return (
    <div className="App">
      <Toolbar currentMode={mode} setMode={setMode} />

      { (isLoading) ? (
        <ContentLoader />
      ) : (
        <>
          <Canvas currentMode={mode} usersColorsMap={usersColorsMap} shapes={shapes} onSelectLoading={setIsPreviewLoading} onSelect={setSelectedShapes} canvasWidth={canvasWidth} canvasHeight={canvasHeight} widthProportion={1} heightProportion={1}/>
          <div className="sidePanel">
            <Legend usersColorsMap={usersColorsMap} />
            <Preview usersColorsMap={usersColorsMap} shapes={selectedShapes} isPreviewLoading={isPreviewLoading} canvasWidth={canvasWidth} canvasHeight={canvasHeight} previewWidth={previewWidth} previewHeight={previewHeight} />
          </div>
        </>
      )}

      <ToastContainer
        position="top-right"
        autoClose={5000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
      />
      <ToastContainer />
    </div>
  );
}

export default App;
