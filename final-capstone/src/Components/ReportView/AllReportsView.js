import { Route } from 'react-router-dom';
import React, { Component } from "react";
import { Box, Card, Content, Title } from 'bloomer';
import Button from '@material-ui/core/Button';
import APImanager from '../APImanager'


export default class AllReportsView extends Component {

    state = {
        reports: []
    }

    // getOneReport = (e) => {
    //     let id = e.target.id;
    //     console.log("click", id)
    //     APImanager.getOneReport(id)
    //         .then((report => {
    //         }))
    // }

    componentDidMount() {
        APImanager.getAllReports()
            .then((reports) => {
                this.setState({
                    reports: reports
                })
            })
    }

    addExpenses = report => {
        let sum = 0
        console.log("report", report)
        if (report.length > 0) {
            let amounts = []
            report.forEach(expense => {
                amounts.push(expense.amount)
            });
            for (let i = 0; i < amounts.length; i++) {
                sum += amounts[i]
            }
            return sum
        }
    }

    // addExpenses = () => {
    //     let reports = this.state.reports
    //     console.log(reports)
    //     reports.forEach(report => {
    //         if (report.expenses.length > 0) {
    //             console.log("report", report.expenses)
    //             let allExpenses = report.expenses
    //             let amounts = []
    //             allExpenses.forEach(expense => {
    //                 amounts.push(expense.amount)
    //                 console.log("amounts", amounts)                    
    //             });
    //             let sum = 0;
    //             for (let i = 0; i < amounts.length; i++) {
    //                 sum += amounts[i]
    //             }
    //             console.log("sum", sum)
    //         }
    //     });
    // }

    render() {
        return (
            <React.Fragment>
                {/* {this.addExpenses()} */}
                <Box>
                    <Button variant="contained" color="primary" onClick={this.props.createReport}>Create Report</Button>
                </Box>
                <Box>
                    <Title isSize={3}>Incomplete Reports</Title>
                    <ul>
                        {this.state.reports.map(report => {
                            if (report.submitted === false) {
                                return (
                                    <Box id={report.id} onClick={this.props.getOneReport}>
                                        <Title isSize={5}>Report:</Title>
                                        <li>{report.purpose}</li>
                                        <Title isSize={5}>Expense Total:</Title>
                                        <p>${this.addExpenses(report.expenses)}</p>
                                    </Box>
                                )
                            }
                        })}
                    </ul>
                </Box>
                <Box>
                    <Title isSize={3}>Completed Reports</Title>
                    <ul>
                        {this.state.reports.map(report => {
                            if (report.submitted === true) {
                                return (
                                    <Box>
                                        <Title isSize={5}>Report:</Title>
                                        <li>{report.purpose}</li>
                                        <Title isSize={5}>Expense Total:</Title>
                                        <p>${this.addExpenses(report.expenses)}</p>
                                    </Box>
                                )
                            }
                        })}
                    </ul>
                </Box>
            </React.Fragment>
        )
    }
}