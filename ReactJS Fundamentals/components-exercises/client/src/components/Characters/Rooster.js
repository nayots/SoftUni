import React from 'react';
import Image from "../Image/Image"

export default class Rooster extends React.Component {
    
    render = () => {
        let images = ""
        if (this.props.charactersData) {
            images = this.props.charactersData.map(i => {
                return <img src={i.url} onClick={() => this.props.updateDetails(i.id)}/>
            });
        }

        return (
            <section id="roster">
                {images}
            </section>
        )
    }
}