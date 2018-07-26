import React from 'react';

export default class Details extends React.Component {
    render = () => (
            <section id="bio">
                <div className="image">
                    <img src={this.props.charData ? this.props.charData.url : ""}/>
                </div>
                <div className="info">
                    <p>Name: {this.props.charData ? this.props.charData.name : ""}<strong></strong></p>
                    <p>Bio: {this.props.charData ? this.props.charData.bio : ""}</p>
                    <p></p>
                </div>
            </section>
        )
}