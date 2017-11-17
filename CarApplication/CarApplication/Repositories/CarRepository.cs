using CarApplication.Entities;
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
    }
}
