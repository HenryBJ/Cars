using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Data;
using Cars.Models;
using Cars.Utils;

namespace Cars.Repositories
{
    public class CarsRepository: ICarsRepository
    {
        private readonly CarsDbContext _context;
        private readonly OwnersProvider _provider;

        public CarsRepository(CarsDbContext context, OwnersProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        public void AddCar(CarModel car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void DeleteCar(CarModel car)
        {
            throw new System.NotImplementedException();
        }

        public List<CarModel> ListCars(int page, int cant)
        {
            throw new System.NotImplementedException();
        }

        public List<OwnerModel> ListOwners()
        {
            return _provider.Owners.ToList();
        }
    }
}