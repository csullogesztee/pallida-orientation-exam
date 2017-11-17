using CarApplication.Entities;
using CarApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarApplication.Repositories
{
    public class CarRepository
    {
        CarContext CarContext;

        public CarRepository(CarContext carcontext)
        {
            CarContext = carcontext;
        }

        public List<Car> SelectCarByPlate(string licensePlate)
        {
            var selectedCars = (from car in CarContext.Cars
                                where car.Plate.Contains(licensePlate)
                                select car).ToList();
            return selectedCars;
        }
    }
}
