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
import APImanager from '../APImanager'

export default class CreateExpenseForm extends Component {

    state = {
        open: false,
        expenseTypes: [],
        description: "",
        amount: "",
        expenseDate: "",
        location: "",
        expenseTypeId: 0,
        reportId: this.props.oneReport.id
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

                    <Button variant="contained" color="primary" onClick={this.props.postExpense}>+</Button>
                </form>
            </React.Fragment>
        )
    }
}