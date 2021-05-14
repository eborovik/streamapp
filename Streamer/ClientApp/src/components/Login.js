import React, { Component } from "react";
import { connect } from 'react-redux';
import { login } from "../actions/Actions";
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';

class Login extends Component {

    constructor(props) {
        super(props);
        this.state = {
            email: '',
            password: ''
        };

        this.onSubmit = this.onSubmit.bind(this);
        this.onChange = this.onChange.bind(this);
    }
    
    onSubmit(e) {
        e.preventDefault();
        this.props.login(this.state).then(
            // make sure we use arrow functions to bind `this` correctly
            (res) => this.props.history.push('/home'),
            (err) => {
                debugger
            });
    }

    onChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    render() {
        const { email, password } = this.state;
        return (
            <div className="inner">
            <form onSubmit={this.onSubmit}>

                <h3>Log in</h3>

                <div className="form-group">
                    <label>Email</label>
                    <input type="email" className="form-control" placeholder="Enter email" name="email" value={email} onChange={this.onChange}/>
                </div>

                <div className="form-group">
                    <label>Password</label>
                    <input type="password" className="form-control" placeholder="Enter password" name="password" value={password} onChange={this.onChange} />
                </div> 

                <button type="submit" className="btn btn-dark btn-lg btn-block">Sign in</button>
                <p className="forgot-password text-right">
                    Forgot <a href="#">password?</a>
                </p>
                </form>
            </div>
        );
    }
}
// let's add some propTypes for additional validation and readability
Login.propTypes = {
    login: PropTypes.func.isRequired
}

// we do not want any state mapped to props, so let's make that first parameter to connect `null`
export default withRouter(connect(null, { login })(Login));