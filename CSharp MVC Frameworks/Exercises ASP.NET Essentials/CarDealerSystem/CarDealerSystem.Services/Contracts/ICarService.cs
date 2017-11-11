using CarDealerSystem.Services.Models.Cars;

namespace CarDealerSystem.Services.Contracts
{
    public interface ICarService
    {
        AllCarsFromMakeModel AllFromMake(string make);

        CarWithPartsModel CarWithParts(int id);

        AddCarModel GetAddCarInfo();

        void AddNewCar(AddCarModel addCarModel);
    }
}