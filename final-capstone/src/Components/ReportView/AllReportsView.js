import { Route } from 'react-router-dom';
import React, { Component } from "react";
import { Box, Card, Content, Title } from 'bloomer';
import Button from '@material-ui/core/Button';
import APImanager from '../APImanager'


export default class AllReportsView extends Component {

    state = {
        reports: []
    }

    componentDidMount() {
        APImanager.getAllReports()
            .then((reports) => {
                console.log("reports", reports)
                this.setState({
                    reports: reports
                })
            })
        // return fetch("https://localhost:5000/api/reports", {
        //     "method": "GET",
        //     "headers": {
        //         "Content-Type": "application/json",
        //         "Authorization": `Bearer ${localStorage.getItem("capstone_token")}`
        //     },
        // })
        //     .then(a => a.json())
        //     .then((reports) => {
        //         console.log("reports", reports)
        //         this.setState({
        //             reports: reports
        //         })
        //     })
    }

    render() {
        return (
            <React.Fragment>
                <Box>
                    <Button variant="contained" color="primary" onClick={this.props.createReport}>Create Report</Button>
                </Box>
                <Box>
                    <Title isSize={4}>Incomplete Reports</Title>
                    <ul>
                        {this.state.reports.map(report => {
                            if (report.submitted === false) {
                                return (
                                    <Card>
                                        <Content>
                                            <li>{report.purpose}</li>
                                        </Content>
                                    </Card>
                                )
                            }
                        })}
                    </ul>
                </Box>
                <Box>
                    <Title isSize={4}>Completed Reports</Title>
                    <ul>
                        {this.state.reports.map(report => {
                            if (report.submitted === true) {
                                return (
                                    <Card>
                                        <Content>
                                            <li>{report.purpose}</li>
                                        </Content>
                                    </Card>
                                )
                            }
                        })}
                    </ul>
                </Box>
            </React.Fragment>
        )
    }
}