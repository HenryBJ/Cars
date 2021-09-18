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

        public void DeleteCar(int carId)
        {
            var item = _context.Cars.Where(e=>e.Id == carId).SingleOrDefault();
            if(item == null) return; //TODO: log, car not found

            _context.Cars.Remove(item);
            _context.SaveChanges();    
                        
        }

        public List<ListCarsViewModel> ListCars(int page, int cant)
        {
            return _context.Cars.ToList()
            .Select(e=> new ListCarsViewModel
            {
                FotoUrl = _provider.Owners.Where(k=>k.Id == e.OwnerModelId).Select(e=>e.Avatar).SingleOrDefault(),
                Id = e.Id,
                Marca = e.Marca,
                Modelo = e.Modelo,
                Patente = e.Patente,
                Puertas = e.Puertas,
                Titular = _provider.Owners.Where(k=>k.Id == e.OwnerModelId).Select(e=>$"{e.First_name} {e.Last_name}").SingleOrDefault()
            })
            .ToList();
        }

        public List<OwnerModel> ListOwners()
        {
            return _provider.Owners.ToList();
        }
    }
}