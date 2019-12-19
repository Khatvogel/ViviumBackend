import React, { Component } from 'react';
import Status from './Status';
import axios from 'axios';

class StartPage extends Component {
  constructor(props) {
    super(props);
    this.state = {
      show: false
    };
  }

  startGame = () => {
    axios.get('https://vivium.azurewebsites.net/attempts/start').then(res => {
      this.setState({ show: true });
    });
  };

  render() {
    return (
      <div>
        {this.state.show ? (
          <Status />
        ) : (
          <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
            <button onClick={this.startGame} type="button" className="btn start-button mt-10">
              Start the Game{' '}
            </button>
          </div>
        )}
      </div>
    );
  }
}
export default StartPage;
