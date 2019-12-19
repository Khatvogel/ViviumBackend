import ProgressBarBootstrap from 'react-bootstrap/ProgressBar';
import React, { Component } from 'react';
import axios from 'axios';

class ProgressBar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      percentage: 0
    };
  }

  componentDidMount() {
    axios.get('https://vivium.azurewebsites.net/attempts/status').then(res => {
      console.log(res);
      this.setState({
        percentage: JSON.stringify(res.data.finishedPercentage)
      });
      console.log(JSON.stringify(this.state.percentage));
    });
    console.log(this.state.percentage);
  }

  render() {
    const { percentage } = this.state;
    if (!percentage) {
      return <div>Loading data from server...</div>;
    }

    return (
      <div>
        <h2>Escape Room Progression</h2>
        <ProgressBarBootstrap
          now={this.state.percentage}
          label={`${this.state.percentage}%`}
          striped
          variant="success"
        />
      </div>
    );
  }
}

export default ProgressBar;
