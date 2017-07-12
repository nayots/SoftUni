using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CarManager
{
    private Dictionary<int, Car> cars = new Dictionary<int, Car>();
    private Dictionary<int, Race> races = new Dictionary<int, Race>();
    private Garage garage = new Garage();

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = null;
        switch (type)
        {
            case "Performance":
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;

            case "Show":
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
        }

        if (!cars.ContainsKey(id))
        {
            cars.Add(id, car);
        }
    }

    public string Check(int id)
    {
        var car = cars[id];

        return car.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        if (!races.ContainsKey(id))
        {
            switch (type)
            {
                case "Casual":
                    races[id] = new CasualRace(length, route, prizePool);
                    break;

                case "Drag":
                    races[id] = new DragRace(length, route, prizePool);
                    break;

                case "Drift":
                    races[id] = new DriftRace(length, route, prizePool);
                    break;
            }
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int lapGold)
    {
        if (!races.ContainsKey(id))
        {
            switch (type)
            {
                case "TimeLimit":
                    races[id] = new TimeLimitRace(length, route, prizePool, lapGold);
                    break;

                case "Circuit":
                    races[id] = new CircuitRace(length, route, prizePool, lapGold);
                    break;
            }
        }
    }

    public void Participate(int carId, int raceId)
    {
        var car = cars[carId];
        var race = races[raceId];

        if (!garage.ParkedCars.Contains(car))
        {
            if ((race.GetType().Name == "TimeLimitRace" && race.Participants.Count == 0) || race.GetType().Name != "TimeLimitRace")
            {
                race.Participants.Add(car);
            }
        }
    }

    public string Start(int raceId)
    {
        var race = races[raceId];

        var result = race.ToString();

        if (race.Participants.Count > 0)
        {
            races.Remove(raceId);
        }

        return result;
    }

    public void Park(int carId)
    {
        var car = cars[carId];

        if (!races.Values.Any(r => r.Participants.Contains(car)))
        {
            if (!garage.ParkedCars.Contains(car))
            {
                garage.ParkedCars.Add(car);
            }
        }
    }

    public void Unpark(int carId)
    {
        var car = cars[carId];

        if (garage.ParkedCars.Contains(car))
        {
            garage.ParkedCars.Remove(car);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var car in garage.ParkedCars)
        {
            car.Tune(tuneIndex, addOn);
        }
    }
}