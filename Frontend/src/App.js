import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Device from './Devices';
import Status from './status/Status';
import Quiz from './quiz/Quiz';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <Router>
        <div>
          <nav className="navbar navbar-dark bg-dark">
            <Link className="nav-link" exact to="/status">
              Status
            </Link>
            <Link className="nav-link" to="/devices">
              Devices
            </Link>
            <Link className="nav-link" to="/quiz">
              Quiz
            </Link>
          </nav>
          <Switch>
            <Route path="/status" component={Status} />

            <Route path="/devices" component={Device} />

            <Route path="/quiz" component={Quiz} />
          </Switch>
        </div>
      </Router>
    </div>
  );
}

export default App;
