import React from "react";

export default class PokemonFormComponent extends React.Component {
  state = {
    pokemon: [],
    name: "",
    image: "",
    info: "",
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

    if (!this.state.name) {
      this.setState({
        generalError: "Name is required"
      });
      return;
    }

    if (!this.state.image) {
      this.setState({
        generalError: "Image is required!"
      });
      return;
    }

    if (!this.state.info) {
      this.setState({
        generalError: "Info is required!"
      });
      return;
    }

    fetch("http://localhost:5000/pokedex/create", {
      method: "POST",
      headers: {
        "content-type": "application/json"
      },
      body: JSON.stringify({
        pokemonName: this.state.name,
        pokemonImg: this.state.image,
        pokemonInfo: this.state.info
      })
    }).then(res =>
      res.json().then(result => {
        this.setState({
          name: "",
          image: "",
          info: ""
        });
        this.getPokemons();
      })
    );
  };

  getPokemons = () => {
    fetch("http://localhost:5000/pokedex/pokedex").then(r =>
      r.json().then(res => {
        this.setState({
          pokemon: res.pokemonColection
        });
      })
    );
  };

  componentDidMount = () => this.getPokemons();

  render() {
    const pokeImages = this.state.pokemon
      ? this.state.pokemon.map((p, ind) => {
          return (
            <div className="imgWrapper">
              <h1>{p.pokemonName}</h1>
              <img className="pokeImg" src={p.pokemonImg} alt={p.pokemonInfo} />
            </div>
          );
        })
      : "";

    return (
      <React.Fragment>
        <form className="center">
          <div>
            <label className="formLabel">Pokemon Name</label>
            <input
              className="formInput"
              name="name"
              onChange={this.handleInputChange}
              value={this.state.name}
            />
          </div>
          <div>
            <label className="formLabel">Pokemon Image</label>
            <input
              className="formInput"
              name="image"
              onChange={this.handleInputChange}
              value={this.state.image}
            />
          </div>
          <div>
            <label className="formLabel">Pokemon Info</label>
            <input
              className="formInput"
              name="info"
              onChange={this.handleInputChange}
              value={this.state.info}
            />
          </div>
          <div>
            <span className="error">{this.state.generalError}</span>
          </div>
          <div>
            <button className="primaryButton" onClick={this.handleFormSubit}>
              Create Pokemon
            </button>
          </div>
        </form>
        {pokeImages}
      </React.Fragment>
    );
  }
}
