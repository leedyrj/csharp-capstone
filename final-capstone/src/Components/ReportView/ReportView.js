import { Route } from 'react-router-dom';
import React, { Component } from "react";
import Navigation from '../nav/navbar';
import { Box, Column, Columns, Title } from 'bloomer';
import Button from '@material-ui/core/Button';


export default class ReportView extends Component {

    state = {
        currentReport: ""
    }



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

    render() {
        return (
            <React.Fragment>
                <Title isSize={4}>
                    {this.props.oneReport.purpose}
                </Title>
                <Box>
                    <Button variant="contained" color="primary" onClick={this.props.createExpense}>Add Expense</Button>
                    <Button variant="contained" color="secondary" onClick={this.getReport}>Submit Report</Button>
                </Box>
            </React.Fragment>
        )
    }
}