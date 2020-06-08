import React, { Component} from 'react';
import { Collapse, Navbar, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {

    ////////////////////////////////////////////////
 static displayName = NavMenu.name;

 constructor() {
     super();

     this.toggleNavbar = this.toggleNavbar.bind(this);
     this.state = { collapsed: true };
 }

 toggleNavbar() {
     this.setState({
         collapsed: !this.state.collapsed
     });
 }

 render() {
     return (
         <Navbar className="navbar navbar-expand-lg   navbar-light shadow " bg="light" expand="lg" variant="light">
             <Link to={"/"}>
                 <img id="logo-nav" className="img-fluid img-responsive" src="https://upload.wikimedia.org/wikipedia/commons/e/e5/FINALLOGO.png" alt="logo" />
             </Link>
             
                 <NavbarToggler onClick={this.toggleNavbar} className="ml-auto" id="toggler" />
             <Collapse className="d-sm-inline-flex " isOpen={!this.state.collapsed} navbar>
                 <NavLink tag={Link} className="dark" to="/">Home</NavLink>
                 <NavLink tag={Link} className="dark" to="/About">About-us</NavLink>
                 <NavLink tag={Link} className="dark" to="/Contact">Contact-Us</NavLink>
                 <NavLink tag={Link} className="dark" to="/Findus">Find-us</NavLink>
               
                
                           
             </Collapse>

                              <NavLink >

                     <Link to="/cart" className="cccard ">
                         <button id="cart" type="submit"><i className="glyphicon ml-auto glyphicon-shopping-cart" /> Cart</button>
                 </Link>
             </NavLink>

             <span>{this.props.isLogin === false && // if not log in yet
                 <NavLink tag={Link} className="dark" to="/login"> <span title="Click to sigin in "></span>
 <i class="fa fa-user" aria-hidden="true"></i>/
                     <i class="fas fa-user-plus"></i>
                 </NavLink>

             }
             </span>
             <span>
                 {this.props.isLogin === true && //if status is logged in
                     <NavLink tag={Link} className="dark" to="/" onClick={this.props.handleLogout}><i class="fas fa-sign-out-alt"></i></NavLink>
                 }
             </span>
             </Navbar>
     );
 }
}
