import React from "react";
import withWarning from "../hoc/withWarning";

class RegisterFormBase extends React.Component {
  render() {
    return (
        <div>
          <header>
            <span class="title">Register</span>
          </header>
          <form>
            Username:
            <input type="text" />
            <br />
            Email:
            <input type="text" />
            <br />
            Password:
            <input type="password" />
            <br />
            Repeat Password:
            <input type="password" />
            <br />
            <input type="submit" value="Register" />
          </form>
        </div>
    );
  }
}

const RegisterForm = withWarning(RegisterFormBase);

export default RegisterForm;
