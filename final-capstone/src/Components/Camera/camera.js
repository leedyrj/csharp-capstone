import React, { Component } from 'react';
import Camera from 'react-html5-camera-photo';
import 'react-html5-camera-photo/build/css/index.css';

class App extends Component {
    onTakePhoto(dataUri) {
        // Do stuff with the dataUri photo...
        console.log('takePhoto');
    }

    render() {
        return (
            <div className="App">
                <Camera
                    onTakePhoto={(dataUri) => { this.onTakePhoto(dataUri); }}
                />
            </div>
        );
    }
}

export default Camera;