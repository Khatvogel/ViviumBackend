import ProgressBarBootstrap from 'react-bootstrap/ProgressBar';
import React, { Component } from 'react';

class ProgressBar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [],
      percentage: 80
    };
  }

  componentDidMount() {
    // database.ref('/').on('value', snapshot => {
    //   this.setState({
    //     data: snapshot.val()
    //   });
    // });
  }

  render() {
    const { data } = this.state;
    if (!data) {
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
