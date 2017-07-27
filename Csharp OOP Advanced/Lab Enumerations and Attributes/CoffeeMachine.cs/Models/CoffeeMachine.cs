using System;
using System.Collections.Generic;
using System.Linq;

public class CoffeeMachine
{
    private IList<Coin> coins;
    private IList<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coins = new List<Coin>();
        this.coffeesSold = new List<CoffeeType>();
    }

    public void BuyCoffee(string size, string type)
    {
        int prize = (int)Enum.Parse(typeof(CoffeePrice), size);
        if (this.coins.Sum(c => (int)c) >= prize)
        {
            CoffeeType cofType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

            this.coffeesSold.Add(cofType);

            this.coins.Clear();
        }
    }

    public void InsertCoin(string coin)
    {
        Coin currentCoin = (Coin)Enum.Parse(typeof(Coin), coin);

        this.coins.Add(currentCoin);
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get
        {
            return this.coffeesSold;
        }
    }
}