import React, { Component } from 'react';

class Checklist extends Component {
  constructor(props) {
    super(props);
    this.state = {
      quizGame: false,
      saltGame: false,
      soapGame: false,
      hideGame: false
    };
  }

  render() {
    return (
      <div className="container m-4">
        <h2> Games finished:</h2>
      </div>
    );
  }
}

export default Checklist;
