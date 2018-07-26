import React from "react"

export default class Image extends React.Component {

    render () {
        return (
            <img
            className={this.props.cssClassName}
            alt={this.props.altName}
            src={this.props.seletedImg}
          />
        )
    }
}