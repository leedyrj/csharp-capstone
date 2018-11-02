import { Route } from 'react-router-dom';
import React, { Component } from "react";
import Navigation from './nav/navbar';
import Report from './ReportView/ReportView';
import AllReports from './ReportView/AllReportsView'
import CreateReportForm from './Forms/CreateReportForm';

export default class Home extends Component {

    state = {
        pageState: "allReports"
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
                console.log("newreport", theNewReport)
            })
            .then(this.setState({
                pageState: "oneReport"
            }))
    }

    render() {
        if (this.state.pageState === "allReports") {
            return (
                <React.Fragment>
                    <Navigation />
                    <AllReports
                        createReport={this.createReport}
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
                    <Report />
                </React.Fragment>
            )
        }
    }
}