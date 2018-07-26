import React from "react";
import "./RegistrationFormComponent.css";

export default class RegistrationFormComponent extends React.Component {
  state = {
    email: "",
    confirmEmail: "",
    userName: "",
    password: "",
    confirmPassword: "",
    terms: false,
    emailError: "",
    userNameError: "",
    passwordError: "",
    termsError: "",
    generalError: ""
  };

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  handleFormSubit = event => {
    event.preventDefault();
    this.setState({
      generalError: ""
    });

    if (
      !this.state.email ||
      !this.state.confirmEmail ||
      this.state.email !== this.state.confirmEmail
    ) {
      this.setState({
        emailError: "Email and Confirm Email are required and must match!"
      });
      return;
    } else {
      this.setState({
        emailError: ""
      });
    }
    if (!this.state.userName) {
      this.setState({
        userNameError: "User Name is required!"
      });
      return;
    } else {
      this.setState({
        userNameError: ""
      });
    }
    if (
      !this.state.password ||
      !this.state.confirmPassword ||
      this.state.password !== this.state.confirmPassword
    ) {
      this.setState({
        passwordError:
          "Password and Confirm Password are required and must match!"
      });
      return;
    } else {
      this.setState({
        passwordError: ""
      });
    }
    if (!this.state.terms) {
      this.setState({
        termsError: "You must agree with the terms to continue!"
      });
      return;
    } else {
      this.setState({
        termsError: ""
      });
    }

    fetch("http://localhost:5000/auth/signup", {
      method: "POST",
      headers: {
        'content-type': 'application/json'
      },
      body: JSON.stringify({
        email: this.state.email,
        password: this.state.password,
        name: this.state.userName
      })
    }).then(res => res.json().then(result => {
        if (result.success) {
          this.props.changeView("login");
          return;
        } else {
          let errorMsg = "";
          for (const key in result.errors) {
            if (result.errors.hasOwnProperty(key)) {
              const element = result.errors[key];
              errorMsg += `${element}\n`
            }
          }

          this.setState({
            generalError: errorMsg
          });
        }
    }));
  };

  render() {
    return (
      <form className="center">
        <div>
          <label className="formLabel">Email</label>
          <input
            className="formInput"
            name="email"
            onChange={this.handleInputChange}
            value={this.state.email}
          />
          <span className="error">{this.state.emailError}</span>
        </div>
        <div>
          <label className="formLabel">Confirm Email</label>
          <input
            className="formInput"
            name="confirmEmail"
            onChange={this.handleInputChange}
            value={this.state.confirmEmail}
          />
        </div>
        <div>
          <label className="formLabel">User Name</label>
          <input
            className="formInput"
            name="userName"
            onChange={this.handleInputChange}
            value={this.state.userName}
          />
          <span className="error">{this.state.userNameError}</span>
        </div>
        <div>
          <label className="formLabel">Password</label>
          <input
            className="formInput"
            type="password"
            name="password"
            onChange={this.handleInputChange}
            value={this.state.password}
          />
          <span className="error">{this.state.passwordError}</span>
        </div>
        <div>
          <label className="formLabel">Confirm Password</label>
          <input
            className="formInput"
            type="password"
            name="confirmPassword"
            onChange={this.handleInputChange}
            value={this.state.confirmPassword}
          />
        </div>
        <div>
          <input
            name="terms"
            type="checkbox"
            onChange={this.handleInputChange}
            checked={this.state.terms}
          />{" "}
          I agree with the terms 👌
          <span className="error">{this.state.termsError}</span>
        </div>
        <div>
          <span className="error">{this.state.generalError}</span>
        </div>
        <div>
          <button className="primaryButton" onClick={this.handleFormSubit}>
            Register
          </button>
          <div>or</div>
          <div>
            <button
              className="secondaryButton"
              onClick={() => this.props.changeView("login")}
            >
              Login
            </button>
          </div>
        </div>
      </form>
    );
  }
}
