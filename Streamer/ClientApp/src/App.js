import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Route, BrowserRouter, Switch, Redirect } from 'react-router-dom'
import Home from './components/Home';
import Records from './components/Records';
import Login from './components/Login';
import Register from './components/Register';
import NavigationBar from './components/NavigationBar'
import './custom.css'

function PrivateRoute({ component: Component, isAuthenticated, ...rest }) {
    return (
    <Route
    {...rest}
    render={(props) => isAuthenticated === true
        ? <Component {...props} />
    : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />}
/>
)
}

// for login/signup
function PublicRoute({ component: Component, isAuthenticated, ...rest }) {
    return (
    <Route
    {...rest}
    render={(props) => isAuthenticated === false
        ? <Component {...props} />
    : <Redirect to='/' />}
/>
)
}

class App extends Component {
    render() {
        return (
        <BrowserRouter>
            <div>
                <NavigationBar />
                <Switch> 
                    <PublicRoute isAuthenticated={this.props.isAuthenticated} path='/login' component={Login} />
                    <PublicRoute isAuthenticated={this.props.isAuthenticated} path='/register' component={Register} />
                    <PrivateRoute isAuthenticated={this.props.isAuthenticated} path='/records' component={Records} />
                    <PrivateRoute isAuthenticated={this.props.isAuthenticated} path='/' component={Home} />\
                    
            {/*<Route render={() => <h3>Not Found 404</h3>} />*/}
                </Switch>
            </div>
        </BrowserRouter>)
}
}

function mapStateToProps(state) {
    return {
        isAuthenticated: state.isAuthenticated
    }
}

export default connect(mapStateToProps)(App)
