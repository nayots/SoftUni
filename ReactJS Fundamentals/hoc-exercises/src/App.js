import React, { Component } from "react";
import "./App.css";
import ArticleTitle from "./components/ArticleTitleComponent/ArticleTitleComponent";
import RegisterForm from "./components/RegisterFormComponent/RegisterFormComponent";
import Navigation from "./components/NavigationComponent/NavigationComponent";
import ErrorBoundary from "./components/ErrorBoundaryComponent/ErrorBoundaryComponent";

class App extends Component {
  render() {
    return (
      <ErrorBoundary>
        <ArticleTitle />
        <RegisterForm />
        <Navigation />
      </ErrorBoundary>
    );
  }
}

export default App;
