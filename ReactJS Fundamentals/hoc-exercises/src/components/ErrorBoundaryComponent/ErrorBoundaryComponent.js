import React from "react";

export default class ErrorBoundary extends React.Component {
    state = {
        hasError: false
    }

    componentDidCatch(error, info) {
        this.setState({
            hasError: true
        });
    }

    render() {
        if (this.state.hasError) {
        return (<h1>Error caught! :)</h1>);
        }
        return this.props.children;
    }
}