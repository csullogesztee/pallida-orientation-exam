using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarApplication.Models
{
    public class Car
    {
        public long Id { get; set; }
        [Display(Name ="License plate")]
        [MaxLength(7, ErrorMessage = "Title field cannot contain more than 7 character!")]
        public string Plate { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }
}
