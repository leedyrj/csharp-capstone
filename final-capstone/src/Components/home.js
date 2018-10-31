import { Route } from 'react-router-dom';
import React, { Component } from "react";
import Navigation from './nav/navbar';
import Report from './ReportView/ReportView';
import AllReports from './ReportView/AllReportsView'

export default class Home extends Component {

    state = {
        pageState: "allReports"
    }

    render() {
        if (this.state.pageState === "allReports") {
            return (
                <React.Fragment>
                    <Navigation />
                    <AllReports />
                </React.Fragment>
            )
        }
        else {
            return (
                <React.Fragment>
                    <Navigation />
                    <Report />
                </React.Fragment>
            )
        }
    }
}