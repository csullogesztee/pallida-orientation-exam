using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarApplication.Repositories;

namespace CarApplication.Controllers
{
    [Route("api")]
    public class RestController : Controller
    {
        CarRepository CarRepository;

        public RestController(CarRepository carRepository)
        {
            CarRepository = carRepository;
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult ListCarsInSameBrand([FromQuery] string brand)
        {
            var selectedCars = CarRepository.SelectCarByBrand(brand);
            return Json(new { result = "ok", data = selectedCars });
        }
    }
}
