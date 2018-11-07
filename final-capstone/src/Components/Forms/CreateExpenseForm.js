import { Route } from 'react-router-dom';
import React, { Component } from "react";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Input from '@material-ui/core/Input';
import { Content } from 'bloomer/lib/elements/Content';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import APImanager from '../APImanager';
import AddPhoto from './AddPhoto';
import request from 'superagent';
import Camera from '../Camera/camera'
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCamera } from '@fortawesome/free-solid-svg-icons'


library.add(faCamera)

const cloudUpPreset = "TravelTrackr"
const cloudUpAddr = "https://api.cloudinary.com/v1_1/dfntrj4nc/upload"

export default class CreateExpenseForm extends Component {

    state = {
        open: false,
        expenseTypes: [],
        description: "",
        amount: 0,
        expenseDate: "",
        location: "",
        expenseTypeId: 0,
        reportId: this.props.oneReport.id,
        selectedFile: null,
        photoString: ""
    }

    handleFieldChange = (evt) => {
        const stateToChange = {}
        stateToChange[evt.target.id] = evt.target.value
        this.setState(stateToChange)
    }

    handleChange = event => {
        this.setState({ [event.target.name]: event.target.value });
    };

    handleClose = () => {
        this.setState({ open: false });
    };

    handleOpen = () => {
        this.setState({ open: true });
    };

    setExpenseType = (e) => {
        let id = e.target.value
        e.preventDefault()
        console.log("click")
        this.setState({
            expenseTypeId: id
        })
    }

    componentDidMount() {
        APImanager.getExpenseTypes()
            .then(expenseTypes => {
                console.log(expenseTypes);
                this.setState({
                    expenseTypes: expenseTypes
                })
            })
    }

    postExpense = () => {
        let body = {
            "reportId": this.state.reportId,
            "description": this.state.description,
            "amount": this.state.amount,
            "expenseDate": this.state.expenseDate,
            "location": this.state.location,
            "expenseTypeId": this.state.expenseTypeId,
        }

        let photobody = {
            "expense":
            {
                "reportId": this.state.reportId,
                "description": this.state.description,
                "amount": this.state.amount,
                "expenseDate": this.state.expenseDate,
                "location": this.state.location,
                "expenseTypeId": this.state.expenseTypeId
            },
            "photoPath": this.state.photoString
        }
        let id = this.state.reportId
        console.log("bodybeforeapi", body)
        APImanager.postExpense(body)
            .then(res => {
                APImanager.postPhoto(photobody)
            }).then(res => {
                this.props.getUpdatedReport(id)
            })
        alert("Successfully saved expense!")
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

    takePic = () => {
        // <Camera
        //     onTakePhoto={(dataUri) => { this.onTakePhoto(dataUri); }}
        // />
    }

    render() {
        return (
            <React.Fragment>
                <form noValidate autoComplete="off">
                    <TextField
                        type="text"
                        id="description"
                        label="Description of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                    />

                    <TextField
                        id="amount"
                        label="Amount of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        type="number"
                    />

                    <TextField
                        id="location"
                        label="Location of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        type="text"
                    />

                    <TextField
                        id="expenseDate"
                        // label="Date of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        type="date"
                    />

                    <InputLabel htmlFor="demo-controlled-open-select">Expense Type</InputLabel>
                    <Select
                        open={this.state.open}
                        onClose={this.handleClose}
                        onOpen={this.handleOpen}
                        value={this.state.age}
                        onChange={this.handleChange}
                        name="expenseTypeId"
                    >
                        {this.state.expenseTypes.map(expenseType => {
                            return <MenuItem value={expenseType.id} id={expenseType.id} >{expenseType.expenseTypeName}</MenuItem>
                        })}
                    </Select>

                    <React.Fragment>
                        <Input type="file" onChange={this.fileSelectHandler} />
                        <Button variant="contained" color="secondary" onClick={() => this.handleImageUpload(this.state.selectedFile)}>Save Photo</Button>
                        <Button variant="contained" onClick={this.takePic}><FontAwesomeIcon icon={faCamera} /></Button>
                    </React.Fragment>

                    <Button variant="contained" color="primary" onClick={this.postExpense} id={this.props.oneReport.id}>Save Expense</Button>
                </form>
            </React.Fragment>
        )
    }
}