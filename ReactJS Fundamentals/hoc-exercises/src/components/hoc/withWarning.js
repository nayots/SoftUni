import React from "react";

const withWarning = WrappedComponent => {
  return class extends React.Component {
    state = {
      hasWarning: false
    };

    swithErrorState = errorState => this.setState({ hasWarning: errorState });

    componentDidMount = () => {
        setTimeout(() => {
            this.setState({
                hasWarning: !this.state.hasWarning
            })
        }, (Math.random() * 5000));
    }
    render() {
      if (this.state.hasWarning) {
        return (
          <React.Fragment>
            <div class="alert">
              <span class="alert-symbol">&#9888;</span>
              <WrappedComponent
                toggleError={this.swithErrorState}
                {...this.props}
              />
            </div>
          </React.Fragment>
        );
      } else {
      }
      return (
        <WrappedComponent toggleError={this.swithErrorState} {...this.props} />
      );
    }
  };
};

export default withWarning;
