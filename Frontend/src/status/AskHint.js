import React, { Component } from 'react';
import axios from 'axios';
import PopupHint from './PopupHint';

class AskHint extends Component {
  constructor(props) {
    super(props);
    this.state = {
      id: null,
      data: null,
      description: 'null',
      show: false
    };
  }

  requestHint = () => {
    axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
    axios
      .get(`https://vivium.azurewebsites.net/hint/new`)
      .then(res => {
        const id = res.data;
        console.log(id);
        return axios.get('https://vivium.azurewebsites.net/hint/answer?id=' + id); // using response.data
      })
      .then(res => {
        this.setState({
          description: res.data
        });
        this.showModal();
      });
  };

  requestAnswer = async () => {
    axios.defaults.headers.accept = 'application/json';
    axios.get('https://vivium.azurewebsites.net/hint/answer?id=2').then(res => {
      this.setState({
        description: res.data
      });
      this.showModal();
    });
    console.log(this.state.data);
  };

  showModal = () => {
    this.setState({ show: true });
  };

  hideModal = () => {
    this.setState({ show: false });
  };

  render() {
    return (
      <div>
        <button type="button" onClick={this.requestAnswer} className="btn start-button">
          Ask a Hint
        </button>
        {this.state.show ? (
          <PopupHint show={this.state.show} handleClose={this.hideModal}>
            <h1>Hint</h1>
            <p>{this.state.description}</p>
          </PopupHint>
        ) : null}
      </div>
    );
  }
}
export default AskHint;
