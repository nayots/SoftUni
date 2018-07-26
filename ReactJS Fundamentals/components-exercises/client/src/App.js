import React, { Component } from 'react';
import './App.css';

import Slider from './components/Slider/Slider';
import Characters from './components/Characters/Characters';

class App extends Component {
    state = {
        epOnFocus: 0
    }

    changeEp = (ep) => {
        this.setState({epOnFocus: ep})
    }
    render() {
        return (
            <div className="container">
                <h1>React Components</h1>
                <Slider updateFunc={this.changeEp} focusedEp={this.state.epOnFocus} />
                <Characters />
            </div>
        );
    }
}

export default App;
