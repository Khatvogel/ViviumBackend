import React, { Component } from 'react';

class Popup extends Component {
  constructor(props) {
    super(props);
    this.state = {
      hide: false
    };
  }

  clicked() {
    this.setState({
      hide: true
    });
  }

  render() {
    return (
      <div>
        <button type="button" class="btn btn-primary" data-toggle="modal" onClick={() => this.clicked()}>
          Click Me
        </button>
        {this.state.hide ? (
          <div class="modal fade" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            Required PopUp{' '}
          </div>
        ) : null}
      </div>
    );
  }
}

export default Popup;
