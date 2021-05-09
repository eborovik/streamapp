import React, { Component } from "react";
import { connect } from 'react-redux';
import { addLiveVideo } from "../actions/Videos";
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';

class Add extends Component {

    constructor(props) {
        super(props);
        this.state = {
            name: ''            
        };

        this.onSubmit = this.onSubmit.bind(this);
        this.onChange = this.onChange.bind(this);
    }

    onSubmit(e) {
        e.preventDefault();
        this.props.addLiveVideo(this.state).then(
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
        const { name } = this.state;
        return (
            <div>
                <input type="text" name="name" value={name} onChange={this.onChange} />
                <button onClick={this.onSubmit}>+</button>
            </div>                        
        );
    }
}
// let's add some propTypes for additional validation and readability
Add.propTypes = {
    login: PropTypes.func.isRequired
}

// we do not want any state mapped to props, so let's make that first parameter to connect `null`
export default withRouter(connect(null, { addLiveVideo })(Add));