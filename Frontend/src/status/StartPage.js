import React, { Component } from 'react';
import axios from 'axios';

class StartPage extends Component {
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

  render() {
    return (
      <div>
        <button type="button" className="btn btn-success">
          Start
        </button>
      </div>
    );
  }
}
export default AskHint;
