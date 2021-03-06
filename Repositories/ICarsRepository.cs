using System.Collections.Generic;
using Cars.Models;

namespace Cars.Repositories
{
    public interface ICarsRepository
    {
        void AddCar(CarModel car);
        void DeleteCar(int carId);
        List<ListCarsViewModel> ListCars(int page, int cant);
        List<OwnerModel> ListOwners();
    }
}