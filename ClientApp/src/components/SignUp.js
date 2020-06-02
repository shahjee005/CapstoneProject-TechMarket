import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './SignIn-SignUp.css'

export class SignUp extends Component {
    static displayName = SignUp.name;

    render() {
        return (
            <div class="fadeInDown">
                <div id="formContent">
                    <Link to="/SignIn"><h2 className="inactive underlineHover" >SignIn</h2></Link>
                    <h2 class="active">SignUp </h2>
                    {/*User icon*/}
                    <div class="fadeIn first">
                        <img src="https://i.ibb.co/Q6xjBKS/Icon1.png" id="icon" alt="User Icon" />
                    </div>
                    {/*SignIn Form*/}
                    <form>
                        <input type="email" id="email" class="fadeIn second" name="signUp" placeholder="Email" />
                        <input type="password" id="password1" class="fadeIn third" name="signUp" placeholder="Password" />
                        <input type="password" id="password2" class="fadeIn third" name="signUp" placeholder="Confirm Password" />
                        <input type="submit" class="fadeIn fourth" value="SignUp" />
                    </form>
                    
                </div>
            </div>
        );
    }
}
                
            