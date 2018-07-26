const pokemons = []

module.exports = {
    addPokem:(data)=>{
        pokemons.push(data)
    },
    retrivePokemons:()=>{
        console.log('hello from database')
        return pokemons
    }
}