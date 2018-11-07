import { Route } from 'react-router-dom';
import React, { Component } from "react";
import APImanager from '../APImanager'
import InputLabel from '@material-ui/core/InputLabel';
import Button from '@material-ui/core/Button';
import Input from '@material-ui/core/Input';
import axios from 'axios';
import request from 'superagent'



const cloudUpPreset = "TravelTrackr"
const cloudUpAddr = "https://api.cloudinary.com/v1_1/dfntrj4nc/upload"


export default class AddPhoto extends Component {

    state = {
        selectedFile: null,
        photoString: ""
    }

    handleImageUpload(file) {
        let upload = request.post(cloudUpAddr)
            .field('upload_preset', cloudUpPreset)
            .field('file', file);

        upload.end((err, response) => {
            if (err) {
                console.error(err);
            }

            if (response.body.secure_url !== '') {
                this.setState(({ photoString }) => ({
                    photoString: (response.body.secure_url),
                }))
            }
        });
    }

    fileSelectHandler = e => {
        this.setState({
            selectedFile: e.target.files[0]
        })
        console.log(e.target.files[0])
    }

    // fileUploadHandler = () => {
    //     console.log("click")
    //     const fd = new FormData()
    //     let body = this.props.oneReport.id
    //     fd.append('image', this.state.selectedFile, this.state.selectedFile.name)
    //     axios({
    //         url: "https://localhost:5000/api/photos",
    //         "method": "POST",
    //         "headers": {
    //             "Content-Type": "application/json",
    //             "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`, "Accept": "application/json"
    //         },
    //         "body": JSON.stringify(
    //             body
    //         )
    //     }).then(res => {
    //         console.log(res)
    //     })
    // }

    render() {
        return (
            <React.Fragment>
                <Input type="file" onChange={this.fileSelectHandler} />
                <Button variant="contained" color="secondary" onClick={() => this.handleImageUpload(this.state.selectedFile)}>Save Photo</Button>
            </React.Fragment>
        )
    }
}