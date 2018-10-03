import React, { Component } from 'react';
import './App.css';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            pathMonthCallSheet: 'http://localhost:51601/report'
        };
    }

    render() {
        return (
            <a href={this.state.pathMonthCallSheet} className="button">Download excel file</a>
        );
    }
  }

export default App;
