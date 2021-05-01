using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Models
{
    public class BrewType
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrewTime { get; set; } //Minutes
        public double CoffeeWaterRation { get; set; }
        public string GrindSize { get; set; }
    }
}
