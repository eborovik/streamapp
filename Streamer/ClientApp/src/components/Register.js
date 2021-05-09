import React, { Component } from "react";
import { connect } from 'react-redux';
import { signup } from "../actions/Actions";
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';

class Register extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name: '',
            email: '',
            password: ''
        };

        this.onChange = this.onChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    }

    onChange(e) {
        // change a key in state with whatever the name attribute is
        // either username or password
        this.setState({ [e.target.name]: e.target.value });
    }

    onSubmit(e) {
        e.preventDefault();
        // make sure we use an arrow function here to correctly bind this to this.props.history.push
        this.props.signup(this.state).then(
            () => {
                // route to /login once signup is complete
                this.props.history.push('/login');
            },
            // if we get back a status code of >= 400 from the server...
            err => {
                // not for production - but good for testing for now!
                debugger;
            }
        );
    }
    render() {
        const { name, email, password } = this.state;
        return (
            <form onSubmit={this.onSubmit}>
                <h3>Register</h3>

                <div className="form-group">
                    <label>Name</label>
                    <input type="text" className="form-control" placeholder="First name"
                        id="name"
                        name="name"
                        value={this.state.name}
                        onChange={this.onChange} />
                </div> 

                <div className="form-group">
                    <label>Email</label>
                    <input type="email" className="form-control" placeholder="Enter email"
                        id="email"
                        name="email"
                        value={this.state.email}
                        onChange={this.onChange} />
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" className="form-control" placeholder="Enter password" type="password"
                        id="password"
                        name="password"
                        value={this.state.password}
                        onChange={this.onChange} />
                </div>

                <button type="submit" className="btn btn-dark btn-lg btn-block">Register</button>
                <p className="forgot-password text-right">
                    Already registered? <a href="/login">log in</a>
                </p>
            </form>
        );
    }
}

Register.propTypes = {
    signup: PropTypes.func.isRequired
};

export default withRouter(connect(null, { signup })(Register));