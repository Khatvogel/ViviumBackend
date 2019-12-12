import React from 'react';
import * as moment from 'moment';
import Sortable from 'react-sortablejs';
import './Devices.css';

const baseUrl = 'https://vivium.azurewebsites.net';

export default class Device extends React.Component {
  state = {
    devices: [],
    loading: false
  };

  componentDidMount() {
    this.fetchDevices();
  }

  async fetchDevices() {
    this.setState({ loading: true });
    const result = await fetch(baseUrl + '/devices');
    const devices = await result.json();
    this.setState({ devices, loading: false });
  }

  async checkedHandler(event, device) {
    await fetch(baseUrl + '/devices/status?macAddress=' + device.MacAddress + '&enabled=' + event.target.checked);
    await this.fetchDevices();
  }

  async onOrderChange(result) {
    this.setState({ loading: true });

    let promises = [];
    result.forEach((item, index) => {
      const device = this.state.devices.find(device => {
        return device.Id === parseInt(item);
      });
      promises.push(fetch(baseUrl + '/devices/position?macAddress=' + device.MacAddress + '&newPosition=' + index));
    });

    Promise.all(promises.map(p => p.catch(e => console.log(e)))).then(results => {
      console.log(results);
      this.fetchDevices();
    });
  }

  async groupDevice(index) {
    const lastOrderPosition = this.state.devices[index - 1].Order;
    const device = this.state.devices[index];

    this.setState({ loading: true });
    await fetch(baseUrl + '/devices/position?macAddress=' + device.MacAddress + '&newPosition=' + lastOrderPosition);
    await this.fetchDevices();
  }

  render() {
    const rows = this.state.devices.map((device, index) => {
      return (
        <tr key={device.Id} data-id={device.Id}>
          <td>{device.MacAddress}</td>
          <td>{device.Name}</td>
          <td>{device.Category}</td>
          <td>{device.Order}</td>
          <td>{moment(device.LastOnline).fromNow()}</td>
          <td className="text-center">
            <input type="checkbox" checked={device.Enabled} onChange={event => this.checkedHandler(event, device)} />
          </td>
          <td>
            {index !== 0 && (
              <button type="button" className="btn btn-success" onClick={() => this.groupDevice(index)}>
                Group
              </button>
            )}
          </td>
        </tr>
      );
    });

    return (
      <div>
        {this.state.loading ? (
          <p>Loading....</p>
        ) : (
          <table border={1}>
            <thead>
              <tr>
                <th>MacAddress</th>
                <th>Name</th>
                <th>Category</th>
                <th>Order</th>
                <th>Last ping</th>
                <th>Enabled</th>
                <th>Group with the above</th>
              </tr>
            </thead>

            <Sortable tag="tbody" onChange={order => this.onOrderChange(order)}>
              {rows}
            </Sortable>
          </table>
        )}
      </div>
    );
  }
}
