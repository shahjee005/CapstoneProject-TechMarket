import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import './SignIn-SignUp.css'

export class SignIn extends Component {
    static displayName = SignIn.name;

    render() {
        return (


            <div class="wrapper fadeInDown">
                <div id="formContent">
                    {/*Titles of my tabs*/}
                    <h2 class="active"> SignIn </h2>
                    <Link to="/SignUp"><h2 className="inactive underlineHover">SignUp</h2></Link>
                    {/*<!-- icons -->*/}
                    <div class="fadeIn first">
                        <img src="https://i.ibb.co/Q6xjBKS/Icon1.png" id="icon" alt="User Icon" />
                    </div>

                    {/*SignIn*/}
                    <form>
                        <input type="text" id="signIn" class="fadeIn second" name="signIn" placeholder="Email" />
                        <input type="text" id="password" class="fadeIn third" name="signIn" placeholder="Password" />
                        <input type="submit" class="fadeIn fourth" value="SignIn" />
                    </form>


                </div>
            </div>

        );
    }
}