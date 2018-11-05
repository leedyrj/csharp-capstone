import { Route } from 'react-router-dom';
import React, { Component } from "react";
import Navigation from '../nav/navbar';
import { Box, Column, Columns, Title } from 'bloomer';
import Button from '@material-ui/core/Button';
import APImanager from '../APImanager';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import ExpansionPanel from '@material-ui/core/ExpansionPanel';
import ExpansionPanelDetails from '@material-ui/core/ExpansionPanelDetails';
import ExpansionPanelSummary from '@material-ui/core/ExpansionPanelSummary';
import Typography from '@material-ui/core/Typography';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';

const styles = theme => ({
    root: {
        width: '100%',
    },
    heading: {
        fontSize: theme.typography.pxToRem(15),
        flexBasis: '33.33%',
        flexShrink: 0,
    },
    secondaryHeading: {
        fontSize: theme.typography.pxToRem(15),
        color: theme.palette.text.secondary,
    },
});


export default class ReportView extends Component {

    state = {
        currentReport: "",
        expanded: null
    }

    handleChange = panel => (event, expanded) => {
        this.setState({
            expanded: expanded ? panel : false,
        });
    };

    deleteExpense = (e) => {
        let id = e.currentTarget.id
        console.log("click", id)
        APImanager.deleteExpense(id)
            .then(deletedExpense => {
                console.log(deletedExpense)
            })
    }

    // putReport = () => {
    //     var today = new Date(),
    //         date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
    //     let id = this.props.oneReport.id
    //     let body = {
    //         "purpose": this.props.oneReport.purpose,
    //         "submitted": true,
    //         "submittedDate": date
    //     }
    //     APImanager.putReport(id, body)
    //         .then(submittedReport => {
    //             console.log(submittedReport)
    //         })
    // }

    // getReport = () => {
    //     fetch("https://localhost:5000/api/reports/3", {
    //         "method": "GET"
    //     })
    //         .then(res => res.json())
    //         .then(OneReport => {
    //             console.log(OneReport)
    //             this.setState({
    //                 currentReport: OneReport
    //             })
    //         })
    // }

    // componentDidMount() {
    //     this.setState({
    //         "currentReport": this.props.oneReport
    //     })
    // }

    render() {
        const { classes } = this.props;
        const { expanded } = this.state;

        if (this.props.oneReport.expenses === null) {
            return (
                <React.Fragment>
                    <Title isSize={4}>
                        {this.props.oneReport.purpose}
                    </Title>
                    <Box>
                        <Button variant="contained" color="primary" onClick={this.props.createExpense}>Add Expense</Button>
                        <Button variant="contained" color="secondary" onClick={this.props.putReport}>Submit Report</Button>
                    </Box>
                </React.Fragment>
            )
        } else {
            return (
                <React.Fragment>
                    <Title isSize={4}>
                        {this.props.oneReport.purpose}
                    </Title>
                    <Box>
                        <Button variant="contained" color="primary" onClick={this.props.createExpense}>Add Expense</Button>
                        <Button variant="contained" color="secondary" onClick={this.props.putReport}>Submit Report</Button>
                    </Box>
                    {this.props.oneReport.expenses.map(expense => {
                        return (
                            <ExpansionPanel>
                                <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
                                    <Title>{expense.description}</Title>
                                </ExpansionPanelSummary>
                                <ExpansionPanelDetails>
                                    <Typography>
                                        ${expense.amount}
                                    </Typography>
                                    <Typography>
                                        {expense.expenseType}
                                    </Typography>
                                    <Typography>
                                        {expense.expenseDate}
                                    </Typography>
                                    <Typography>
                                        {expense.location}
                                    </Typography>
                                    <div>
                                        <Button variant="contained" color="primary">Edit Expense</Button>
                                        <Button variant="contained" color="secondary" id={expense.id} onClick={this.deleteExpense}>Delete Expense</Button>
                                    </div>
                                </ExpansionPanelDetails>
                            </ExpansionPanel>
                        )
                    })}
                </React.Fragment>
            )
        }
    }
}