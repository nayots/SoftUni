using CarDealerSystem.Data.Models;
using CarDealerSystem.Services.Contracts;
using CarDealerSystem.Services.Models.Cars;
using CarDealerSystem.Services.Models.Parts;
using CarDealerSystem.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace CarDealerSystem.Services
{
    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void AddNewCar(AddCarModel addCarModel)
        {
            List<PartCar> parts = this.db.Parts
                .Where(p => addCarModel.Parts.Any(sp => sp == p.Id))
                .Select(p => new PartCar() { PartId = p.Id })
                .ToList();

            var car = new Car()
            {
                Make = addCarModel.Make,
                Model = addCarModel.Model,
                TravelledDistance = addCarModel.TravelledDistance.Value,
                Parts = parts
            };

            this.db.Cars.Add(car);

            this.db.SaveChanges();
        }

        public AllCarsFromMakeModel AllFromMake(string make)
        {
            var query = this.db.Cars.AsQueryable();

            if (!string.Equals(make, "All", System.StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.Make == make).AsQueryable();
            }

            var result = new AllCarsFromMakeModel
            {
                Cars = query
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarFromMakeModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                }).ToList()
            };

            return result;
        }

        public CarWithPartsModel CarWithParts(int id)
        {
            if (!this.db.Cars.Any(c => c.Id == id))
            {
                return default(CarWithPartsModel);
            }

            var car = this.db.Cars.First(c => c.Id == id);

            db.Entry(car).Collection(c => c.Parts).Load();
            car.Parts.ToList().ForEach(p => this.db.Entry(p).Reference(pp => pp.Part).Load());

            var result = new CarWithPartsModel()
            {
                Make = car.Make,
                Model = car.Model,
                TravelledDistance = car.TravelledDistance,
                Parts = car.Parts.Select(p => new PartModel
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price
                }).ToList()
            };

            return result;
        }

        public AddCarModel GetAddCarInfo()
        {
            var model = new AddCarModel()
            {
                AvailableParts = this.db.Parts.Select(p => new PartSelectModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
            };

            return model;
        }
    }
}