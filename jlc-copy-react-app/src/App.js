import React, { Component } from 'react';
import './App.css';

class App extends Component {

    handleClick = () => {
        return "http://localhost:51601/report";
    }

    render() {
        return (
            <a href={this.handleClick()} class="button">Download excel file</a>
        );
    }
  //render() {
  //  return (
  //    <div className="App">
  //      <header className="App-header">
  //        <img src={logo} className="App-logo" alt="logo" />
  //        <h1 className="App-title">Welcome to React</h1>
  //      </header>
  //      <p className="App-intro">
  //        To get started, edit <code>src/App.js</code> and save to reload.
  //      </p>
  //    </div>
  //  );
  //}
}

export default App;
