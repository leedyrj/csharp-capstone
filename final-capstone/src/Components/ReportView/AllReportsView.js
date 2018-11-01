import { Route } from 'react-router-dom';
import React, { Component } from "react";
import { Box } from 'bloomer';
import Button from '@material-ui/core/Button';


export default class AllReportsView extends Component {

    state = {
        reports: []
    }

    componentDidMount() {
        return fetch("https://localhost:5000/api/reports", {
            "method": "GET"
        })
            .then(a => a.json())
            .then((reports) => {
                console.log("reports", reports)
                this.setState({
                    reports: reports
                })
            })
    }

    render() {
        return (
            <React.Fragment>
                <Box>
                    <Button variant="contained" color="primary" onClick={this.props.createReport}>Create Report</Button>
                </Box>
                <Box>
                    {/* <ul>
                        {this.state.reports.}
                    </ul> */}
                </Box>
            </React.Fragment>
        )
    }
}