import React, { Component } from "react";
import "./app.css";
const userData = require("./contacts.json");

class App extends Component {
  contacts = userData;

  state = {
    details: null,
    count: 0,
    time: new Date()
  };

  handleClick = personId => {
    let personDetails = this.contacts[personId];

    let details = (
      <React.Fragment>
        <div className="info">
          <div className="col">
            <span className="avatar">&#9787;</span>
          </div>
          <div className="col">
            <span className="name">{personDetails.firstName}</span>
            <span className="name">{personDetails.lastName}</span>
          </div>
        </div>
        <div className="info">
          <span className="info-line">☎ {personDetails.phone}</span>
          <span className="info-line">✉ {personDetails.email}</span>
        </div>
      </React.Fragment>
    );

    this.setState({
      details: details
    });
  };

  handleButton = () => {
    this.setState({
      count: this.state.count + 1
    });
  };

  createContact = (userInfo, index) => {
    return (
      <div
        className="contact"
        key={index}
        data-id={index}
        onClick={() => this.handleClick(index)}
      >
        <span className="avatar small">&#9787;</span>
        <span className="title">
          {userInfo.firstName} {userInfo.lastName}
        </span>
      </div>
    );
  };

  componentDidMount() {
    this.clockTImer = setInterval(() => {
      this.setState({
        time: new Date()
      });
    }, 1000);
  }

  componentWillUnmount() {
    clearInterval(this.clockTImer);
  }

  render() {
    return (
      <div className="container">
        <header>&#9993; Contact Book</header>
        <div id="book">
          <div id="list">
            <h1>Contacts</h1>
            <div className="content">
              {this.contacts.map((c, i) => this.createContact(c, i))}
            </div>
          </div>
          <div id="details">
            <h1>Details</h1>
            <div className="content">{this.state.details}</div>
          </div>
        </div>
        <div className="counter">
          {this.state.count}
          <button className="counterButton" onClick={this.handleButton}>
            Counter ++
          </button>
        </div>
        <div className="clock">{this.state.time.toLocaleString()}</div>
        <footer>Contact Book SPA &copy; 2017</footer>
      </div>
    );
  }
}

export default App;
