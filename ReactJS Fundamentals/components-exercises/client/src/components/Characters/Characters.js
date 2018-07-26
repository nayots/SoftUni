import React from 'react';

import Rooster from './Rooster';
import Details from './Details';
import fetcher from '../../fetcher';

const ROOSTER_ENPOINT = '/roster';
const DETAILS_ENDPOINT = '/character/';

export default class Characters extends React.Component {

    state = {
        focusedChar: ""
    }

    updateDetails = (id) => {
        fetch('http://localhost:9999' + DETAILS_ENDPOINT + `${id}`)
        .then(data => {
          return data.json()
        })
        .then(parseData => {
          this.promisfyState({ focusedChar: parseData }).then(() => {
              console.log(parseData);
              
            console.log('loaded new state')
          })
        }) 
    }

    promisfyState = obj => {
        return new Promise(res => {
            this.setState(obj, res)
        }).catch(e => {
            console.log(e); 
        });
    }

    componentWillMount() {
        fetch('http://localhost:9999' + ROOSTER_ENPOINT)
        .then(data => {
          return data.json()
        })
        .then(parseData => {
          this.promisfyState({ rosterData: parseData }).then(() => {
              console.log(parseData);
              
            console.log('loaded new state')
          })
        })
        fetch('http://localhost:9999' + DETAILS_ENDPOINT + `0`)
        .then(data => {
          return data.json()
        })
        .then(parseData => {
          this.promisfyState({ focusedChar: parseData }).then(() => {
              console.log(parseData);
              
            console.log('loaded new state')
          })
        }) 
    }

    render = () => (        
            <div>
                <Rooster charactersData={this.state.rosterData} updateDetails={this.updateDetails}/>
                <Details charData={this.state.focusedChar}/>
            </div>
        )
}