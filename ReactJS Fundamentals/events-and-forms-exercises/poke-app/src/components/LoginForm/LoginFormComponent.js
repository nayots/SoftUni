import React from "react";
import Auth from "../../services/Auth";

export default class LoginFormComponent extends React.Component {
  state = {
    email: "",
    password: "",
    emailError: "",
    passwordError: "",
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

    if (!this.state.email) {
      this.setState({
        emailError: "Email is required"
      });
      return;
    } else {
      this.setState({
        emailError: ""
      });
    }

    if (!this.state.password) {
      this.setState({
        passwordError: "Password is required!"
      });
      return;
    } else {
      this.setState({
        passwordError: ""
      });
    }

    fetch("http://localhost:5000/auth/login", {
      method: "POST",
      headers: {
        'content-type': 'application/json'
      },
      body: JSON.stringify({
        email: this.state.email,
        password: this.state.password
      })
    }).then(res => res.json().then(result => {
        if (result.success) {
          this.props.saveUser(result.user);
          Auth.authenticateUser(result.token);
          this.props.changeView("poke");
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
          <span className="error">{this.state.generalError}</span>
        </div>
        <div>
          <button className="primaryButton" onClick={this.handleFormSubit}>
            Login
          </button>
          <div>or</div>
          <div>
            <button
              className="secondaryButton"
              onClick={() => this.props.changeView("register")}
            >
              Register
            </button>
          </div>
        </div>
      </form>
    );
  }
}
