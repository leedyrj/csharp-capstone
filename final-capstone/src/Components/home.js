import { Route } from 'react-router-dom';
import React, { Component } from "react";
import Navigation from './nav/navbar';
import Report from './ReportView/ReportView';
import AllReports from './ReportView/AllReportsView'
import CreateReportForm from './Forms/CreateReportForm';
import APImanager from './APImanager';
import CreateExpenseForm from './Forms/CreateExpenseForm';

export default class Home extends Component {

    state = {
        pageState: "allReports",
        oneReport: {}
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
        let id = e.target.id;
        console.log("click", id)
        APImanager.getOneReport(id)
            .then((report => {
                this.setState({
                    pageState: "oneReport",
                    oneReport: report
                })
            }))
    }

    getUpdatedReport = (e) => {
        let id = this.state.oneReport.id
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
                    />
                </React.Fragment>
            )
        }
    }
}