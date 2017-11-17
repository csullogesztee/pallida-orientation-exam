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
            return View();
        }

        [HttpPost]
        [Route("/search")]
        public IActionResult ListCars(string plate)
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
                    return RedirectToAction("DisplayCars", carList);
                }
            }
            else
            {
                return RedirectToAction("DisplayCars", carList);
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
        [Route("/search")]
        public IActionResult ListFilteredCarsByBrand([FromQuery] string filter)
        {
            var carList = CarRepository.SelectCarsByBrand(filter);
            return View("DisplayCars", carList);
        }
    }
}
