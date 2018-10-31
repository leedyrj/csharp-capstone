import { Route } from 'react-router-dom'
import React, { Component } from "react"
import Login from './auth/APILogin';
import Navigation from './nav/navbar';
import Home from './home';

export default class ApplicationViews extends Component {

    isAuthenticated = () =>
        localStorage.getItem("capstone_token") !== null ||
        sessionStorage.getItem("capstone_token") !== null;

    render() {
        return (
            <React.Fragment>
                <Route exact path="/"
                    render={props => {
                        if (this.isAuthenticated()) {
                            return <Home />;
                        } else {
                            return <Login />;
                        }
                    }}
                />
                {/* <Route path="/Register" component={Register} /> */}
                <Route path="/Login" component={Login} />
            </React.Fragment>
        )
    }
}
