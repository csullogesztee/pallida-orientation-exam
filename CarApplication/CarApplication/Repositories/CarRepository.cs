using CarApplication.Entities;
using CarApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarApplication.Repositories
{
    public class CarRepository
    {
        CarContext CarContext;

        public CarRepository(CarContext carcontext)
        {
            CarContext = carcontext;
        }

        public List<Car> SelectCarsByPlate(string licensePlate)
        {
            var selectedCars = (from car in CarContext.Cars
                                where car.Plate.Contains(licensePlate)
                                select car).ToList();
            return selectedCars;
        }

        public List<Car> SelectCarsByBrand(string brand)
        {
            var selectedCars = (from car in CarContext.Cars
                                where car.CarBrand == brand
                                select car).ToList();
            return selectedCars;
        }

        public List<Car> SelectCarsByFilter(string filter)
        {
            var selectedCarsList = new List<Car>();

            if (filter == "police")
            {
                var selectedCars = (from car in CarContext.Cars
                                    where car.Plate.Contains("RB")
                                    select car).ToList();
                selectedCarsList = selectedCars;
            }
            else if (filter == "diplomat")
            {
                var selectedCars = (from car in CarContext.Cars
                                   where car.Plate.Contains("DT")
                                   select car).ToList();
                selectedCarsList = selectedCars;
            }
            return selectedCarsList;
        }
    }
}
