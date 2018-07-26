import React from "react";
import "./App.css";
import RegistrationFormComponent from "./components/RegistrationForm/RegistrationFormComponent";
import LoginFormComponent from "./components/LoginForm/LoginFormComponent";
import PokemonFormComponent from "./components/PokemonForm/PokemonFormComponent";
import Auth from "./services/Auth";

class App extends React.Component {
  state = {
    user: null,
    currentView: "register",
    authenticated: false
  };

  switchView = viewName => {
    this.toggleAuthenticateStatus();
    this.setState({
      currentView: viewName
    });
  };

  setCurrentUser = userData => {
    this.setState({
      user: userData
    });
  };

  componentDidMount = () => {
    this.toggleAuthenticateStatus()
  }

  toggleAuthenticateStatus = () => {
    // check authenticated status and toggle state based on that
    this.setState({ authenticated: Auth.isUserAuthenticated() })
  }
  render() {
    let view = "";
    if (this.state.authenticated) {
      view = <PokemonFormComponent />;
    } else {
      switch (this.state.currentView) {
        case "login":
          view = (
            <LoginFormComponent
              changeView={this.switchView}
              saveUser={this.setCurrentUser}
            />
          );
          break;
        case "register":
        default:
          view = <RegistrationFormComponent changeView={this.switchView} />;
          break;
      }
    }

    return <div className="App">{view}</div>;
  }
}

export default App;
