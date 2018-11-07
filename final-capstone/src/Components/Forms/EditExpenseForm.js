import { Route } from 'react-router-dom';
import React, { Component } from "react";
import PropTypes from 'prop-types';
import classNames from 'classnames';
import { withStyles } from '@material-ui/core/styles';
import MenuItem from '@material-ui/core/MenuItem';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { Content } from 'bloomer/lib/elements/Content';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import APImanager from '../APImanager';
import AddPhoto from './AddPhoto'

export default class EditExpenseForm extends Component {

    state = {
        open: false,
        expenseTypes: [],
        description: this.props.expenseToEdit.description,
        amount: this.props.expenseToEdit.amount,
        expenseDate: this.props.expenseToEdit.expenseDate,
        location: this.props.expenseToEdit.location,
        expenseTypeId: this.props.expenseToEdit.expenseTypeId,
        reportId: this.props.oneReport.id,
        editedReport: []
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

    putExpense = () => {
        let body = {
            "reportId": this.state.reportId,
            "description": this.state.description,
            "amount": this.state.amount,
            "expenseDate": this.state.expenseDate,
            "location": this.state.location,
            "expenseTypeId": this.state.expenseTypeId,
            "id": this.props.expenseToEdit.id
        }
        let id = this.props.expenseToEdit.id
        let repId = this.state.reportId
        console.log("id", id)
        console.log("bodybeforeapi", body)
        APImanager.putExpense(id, body)
            .then((editedExpense) => {
                this.props.getUpdatedReport(repId)
            })
    }

    render() {
        return (
            <React.Fragment>
                <form noValidate autoComplete="off">
                    <TextField
                        type="text"
                        id="description"
                        label="expense desciritpion"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        value={this.state.description}
                    />

                    <TextField
                        id="amount"
                        label="Amount of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        type="number"
                        value={this.state.amount}
                    />

                    <TextField
                        id="location"
                        label="Location of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        type="text"
                        value={this.state.location}
                    />

                    <TextField
                        id="expenseDate"
                        // label="Date of Expense"
                        onChange={this.handleFieldChange}
                        margin="normal"
                        type="date"
                        value={this.state.expenseDate}
                    />

                    <InputLabel htmlFor="demo-controlled-open-select">Expense Type</InputLabel>
                    <Select
                        open={this.state.open}
                        onClose={this.handleClose}
                        onOpen={this.handleOpen}
                        value={this.state.expenseTypeId}
                        onChange={this.handleChange}
                        name="expenseTypeId"
                    >
                        {this.state.expenseTypes.map(expenseType => {
                            return <MenuItem value={expenseType.id} id={expenseType.id} >{expenseType.expenseTypeName}</MenuItem>
                        })}
                    </Select>

                    <AddPhoto oneReport={this.props.oneReport} />

                    <Button variant="contained" color="primary" onClick={this.putExpense} id={this.props.oneReport.id}>+</Button>
                </form>
            </React.Fragment>
        )
    }
}