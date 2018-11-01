import { Route } from 'react-router-dom';
import React, { Component } from "react";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { Content } from 'bloomer/lib/elements/Content';


export default class CreateReportForm extends Component {

    state = {
        purpose: ""
    }



    // postReport = () => {
    //     console.log("click")
    //     return fetch("https://localhost:5000/api/reports", {
    //         "method": "POST",
    //         "headers": {
    //             "Content-Type": "application/json",
    //             // "Authorization": `Bearer ${localStorage.getItem("jukebox_token")}`
    //         },
    //         "body": JSON.stringify({
    //             "employeeId": "06bd1516-2457-4f2c-b2f6-98637f946401",
    //             "purpose": this.state.purpose
    //         })
    //     })
    //         .then(a => a.json())
    //         .then(theNewReport => {
    //             console.log(theNewReport)
    //         })
    //         .then(this.setState() {

    //         })
    // }

    render() {
        return (
            <React.Fragment>
                <form noValidate autoComplete="off">
                    <TextField
                        id="purpose"
                        label="Destination/Purpose"
                        value={this.state.name}
                        onChange={this.props.handleFieldChange}
                        margin="normal"
                    />
                    <Button variant="contained" color="primary" onClick={this.props.postReport}>+</Button>
                </form>
            </React.Fragment>
        )
    }
}