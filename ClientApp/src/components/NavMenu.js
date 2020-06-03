import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
         <img id="logo-nav" className="img-fluid img-responsive" src="https://upload.wikimedia.org/wikipedia/commons/5/52/MYLAST_LOGO.png" alt="logo" />
         
       <NavbarToggler onClick={this.toggleNavbar} className="mr-2" id="toggler" />
            
              <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                <NavItem>
                <NavLink tag={Link} className="text-dark" to="/validate">validate</NavLink>
                </NavItem>
                <NavItem>
                <NavLink tag={Link} className="text-dark" to="/SignIn">SignIn/SignUp</NavLink>
               </NavItem>
              </ul>
              </Collapse>
              <button id="cart" type="submit"><i className="glyphicon glyphicon-shopping-cart" /> My Cart</button>
          </Container>
        </Navbar>
        </header>
    );
  }
}
