import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Device from './Devices';
import Status from './status/Status';
import Quiz from './quiz/Quiz';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Vivium Devices</h1>
        <Device />
      </header>

      <header className="App-header">
        <h1>Status</h1>
        <Status />
      </header>

      <header className="App-header">
        <h1>Quiz</h1>
        <Quiz />
      </header>
    </div>
  );
}

export default App;
