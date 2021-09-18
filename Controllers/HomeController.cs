using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cars.Models;
using Cars.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cars.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarsRepository _repo;

        public HomeController(ILogger<HomeController> logger, ICarsRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.list  = _repo.ListOwners()
            .Select(e=>new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = $"{e.First_name} {e.Last_name}"                 
            })
            .Append(new SelectListItem{Value="0", Text="Seleccione el titular del carro"})
            .OrderBy(e=>e.Value);
            return View();
        }


        public IActionResult OnInsert(CarViewModel model)
        {
            if(ModelState.IsValid)
            {
                _repo.AddCar(new CarModel
                {
                    Marca = model.Marca,
                    Modelo = model.Modelo,
                    Patente = model.Patente,
                    Puertas = model.Puertas,
                    OwnerModelId = model.OwnerId  
                });
            }           

            ModelState.Clear();
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
