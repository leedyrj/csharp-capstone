import { Route } from 'react-router-dom';
import React, { Component } from "react";
import Navigation from './nav/navbar';
import Report from './ReportView/ReportView';
import AllReports from './ReportView/AllReportsView'
import CreateReportForm from './Forms/CreateReportForm';
import APImanager from './APImanager';
import CreateExpenseForm from './Forms/CreateExpenseForm';
import EditExpenseForm from './Forms/EditExpenseForm';

export default class Home extends Component {

    state = {
        pageState: "allReports",
        oneReport: {},
        expenseToEdit: []
    }

    createReport = () => {
        this.setState({
            pageState: "CreateReportForm"
        })
    }

    handleFieldChange = (evt) => {
        const stateToChange = {}
        stateToChange[evt.target.id] = evt.target.value
        this.setState(stateToChange)
    }

    postReport = () => {
        return fetch("https://localhost:5000/api/reports", {
            "method": "POST",
            "headers": {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
            },
            "body": JSON.stringify({
                "purpose": this.state.purpose
            })
        })
            .then(a => a.json())
            .then(theNewReport => {
                this.setState({
                    pageState: "oneReport",
                    oneReport: theNewReport
                })
            })
    }

    // putExpense = () => {
    //     let body = {
    //         "reportId": this.state.reportId,
    //         "description": this.state.description,
    //         "amount": this.state.amount,
    //         "expenseDate": this.state.expenseDate,
    //         "location": this.state.location,
    //         "expenseTypeId": this.state.expenseTypeId
    //     }
    //     let id = this.state.oneReport.id
    //     console.log("bodybeforeapi", body)
    //     APImanager.postExpense(id, body)
    //         .then((addedReport) => {
    //             // console.log("body", body)
    //             // console.log("addedreport", addedReport)
    //             this.getUpdatedReport()
    //                 .then(updatedExpense => {
    //                     console.log(updatedExpense)
    //                 })
    //         })
    // }

    putReport = () => {
        var today = new Date(),
            date = today.getFullYear() + '-' + (today.getMonth() + 1) + '-' + today.getDate();
        let id = this.state.oneReport.id
        console.log(this.state.oneReport.purpose)
        let body = {
            "id": this.state.oneReport.id,
            "purpose": this.state.oneReport.purpose,
            "submitted": true,
            "submittedDate": date
        }
        APImanager.putReport(id, body)
            .then(submittedReport => {
                console.log(submittedReport)
                this.setState({
                    pageState: "allReports"
                })
            })
    }

    getOneReport = (e) => {
        let id = e.currentTarget.id;
        console.log("click", id)
        APImanager.getOneReport(id)
            .then((report => {
                this.setState({
                    pageState: "oneReport",
                    oneReport: report
                })
            }))
    }

    getOneExpense = (e) => {
        let id = e.currentTarget.id
        APImanager.getOneExpense(id)
            .then((expense => {
                this.setState({
                    pageState: "EditExpenseForm",
                    expenseToEdit: expense
                })
            }))
    }

    getUpdatedReport = (id) => {
        // console.log("id", id)
        APImanager.getOneReport(id)
            .then((report => {
                this.setState({
                    pageState: "oneReport",
                    oneReport: report
                })
            }))
    }

    createExpense = () => {
        this.setState({
            pageState: "CreateExpenseForm"
        })
    }

    render() {
        if (this.state.pageState === "allReports") {
            return (
                <React.Fragment>
                    <Navigation />
                    <AllReports
                        createReport={this.createReport}
                        getOneReport={this.getOneReport}
                    />
                </React.Fragment>
            )
        }
        else if (this.state.pageState === "CreateReportForm") {
            return (
                <React.Fragment>
                    <Navigation />
                    <CreateReportForm
                        postReport={this.postReport}
                        handleFieldChange={this.handleFieldChange}
                    />
                </React.Fragment>
            )
        }
        else if (this.state.pageState === "oneReport") {
            return (
                <React.Fragment>
                    <Navigation />
                    <Report
                        oneReport={this.state.oneReport}
                        createExpense={this.createExpense}
                        putReport={this.putReport}
                        getOneExpense={this.getOneExpense}
                        getUpdatedReport={this.getUpdatedReport}

                    />
                </React.Fragment>
            )
        }
        else if (this.state.pageState === "CreateExpenseForm") {
            return (
                <React.Fragment>
                    <Navigation />
                    <CreateExpenseForm
                        handleFieldChange={this.handleFieldChange}
                        oneReport={this.state.oneReport}
                        getUpdatedReport={this.getUpdatedReport}
                        getOneReport={this.getOneReport}
                    />
                </React.Fragment>
            )
        }
        else if (this.state.pageState === "EditExpenseForm") {
            return (
                <React.Fragment>
                    <Navigation />
                    <EditExpenseForm
                        handleFieldChange={this.handleFieldChange}
                        oneReport={this.state.oneReport}
                        getUpdatedReport={this.getUpdatedReport}
                        expenseToEdit={this.state.expenseToEdit}
                        putExpense={this.putExpense}
                    />
                </React.Fragment>
            )
        }
    }
}