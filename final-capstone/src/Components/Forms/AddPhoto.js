import { Route } from 'react-router-dom';
import React, { Component } from "react";
import APImanager from '../APImanager'
import InputLabel from '@material-ui/core/InputLabel';
import Button from '@material-ui/core/Button';
import Input from '@material-ui/core/Input';
import axios from 'axios';



export default class AddPhoto extends Component {

    state = {
        selectedFile: null
    }

    fileSelectHandler = e => {
        this.setState({
            selectedFile: e.target.files[0]
        })
    }

    fileUploadHandler = () => {
        const fd = new FormData()
        let body = this.props.oneReport.id
        fd.append('image', this.state.selectedFile, this.state.selectedFile.name)
        axios.post(APImanager.postPhoto(body), fd)
            .then(res => {
                console.log(res)
            })
    }

    render() {
        return (
            <React.Fragment>
                <Input type="file" onChange={this.fileSelectHandler} />
                <Button variant="contained" color="secondary" onClick={this.fileUploadHandler}>Save Photo</Button>
            </React.Fragment>
        )
    }
}