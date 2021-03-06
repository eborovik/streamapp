import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { connect } from 'react-redux';
import { logout } from '../actions/Actions';
import './NavMenu.css'

class NavigationBar extends Component {
    logout(e) {
        e.preventDefault();
        this.props.logout();
    }

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        const userLinks = (
            <ul className="nav navbar-nav navbar-right">
                <li><a href="#" onClick={this.logout.bind(this)}>Logout</a></li>
            </ul>
        );

        const guestLinks = (
            <ul className="navbar-nav flex-grow">
                <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/login">Login</NavLink>
                </NavItem>
                <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/register">SignUp</NavLink>
                </NavItem>
            </ul>
        );

        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/">Streamer</NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                    
                            <div >
                                {this.props.auth ? userLinks : guestLinks}
                            </div>
                            
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }
}

function mapStateToProps(state) {
    return {
        auth: state.isAuthenticated
    };
}

export default connect(mapStateToProps, { logout })(NavigationBar);