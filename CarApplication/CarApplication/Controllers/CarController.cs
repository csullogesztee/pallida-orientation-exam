
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CarApplication.Repositories;

namespace CarApplication.Controllers
{
    [Route("")]
    public class CarController : Controller
    {
        CarRepository CarRepository;

        public CarController(CarRepository carRepository)
        {
            CarRepository = carRepository;
        }

        [HttpGet]
        public IActionResult LicensePlateForm()
        {
            return View();
        }

        [HttpPost]
        [Route("/search")]
        public IActionResult ListCars(string plate)
        {
            var carList = CarRepository.SelectCarsByPlate(plate);
            if (carList.Count() == 0)
            {
                string message = "Sorry, the submitted licence plate is not valid";
                return RedirectToAction("LicensePlateForm", message);
            }
            return RedirectToAction("LicensePlateForm", carList);
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult ListFilteredCars([FromQuery] string filter)
        {
            return View();
        }
    }
}
