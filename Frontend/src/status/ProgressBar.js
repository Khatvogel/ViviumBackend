import ProgressBarBootstrap from 'react-bootstrap/ProgressBar';
import React, { Component } from 'react';
import axios from 'axios';
import './ProgressBar.css';

class ProgressBar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      percentage: 0
    };
  }

  componentDidMount() {
    this.updateStatus();
    setInterval(() => this.updateStatus(), 5000);
  }

  updateStatus() {
    axios.get('https://vivium.azurewebsites.net/attempts/status').then(res => {
      console.log(res);
      this.setState({
        percentage: JSON.stringify(res.data.finishedPercentage)
      });
      console.log(JSON.stringify(this.state.percentage));
    });
  }

  render() {
    const { percentage } = this.state;
    if (!percentage) {
      return <div>Loading data from server...</div>;
    }

    return (
      <div className="progressbar-vivium">
        <ProgressBarBootstrap now={this.state.percentage} variant="primary" />

        <div style={{ marginTop: 10 }}>
          <span>
            You guys are at <strong>{this.state.percentage}</strong> percent...
          </span>
        </div>
      </div>
    );
  }
}

export default ProgressBar;
