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
        public IActionResult DisplayCars()
        {
            return PartialView("LicensePlateForm");
        }

        [HttpPost]
        [Route("/search")]
        public IActionResult DisplayCars(string plate)
        {
            var carList = CarRepository.SelectCarsByPlate(plate);
            if (ModelState.IsValid)
            {
                if (carList.Count() == 0)
                {
                    string message = "Sorry, the submitted licence plate is not valid";
                    return RedirectToAction("DisplayCars", message);
                }
                else
                {
                    return View("DisplayCars", carList);
                }
            }
            else
            {
                return View("DisplayCars", carList);
            }    
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult ListFilteredCars([FromQuery] string filter)
        {
            var carList = CarRepository.SelectCarsByFilter(filter);
            return View("DisplayCars", carList);
        }

        [HttpGet]
        [Route("/search/{brand}")]
        public IActionResult ListFilteredCarsByBrand([FromQuery] string filter)
        {
            var carList = CarRepository.SelectCarsByBrand(filter);
            return View("DisplayCars", carList);
        }
    }
}
