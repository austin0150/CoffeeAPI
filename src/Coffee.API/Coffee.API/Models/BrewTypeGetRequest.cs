using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Models
{
    public class BrewTypeGetRequest
    {
        public string BrewTypeAttribute { get; set; }
        public string AttributeValue { get; set; }
        public bool ExactMatch { get; set; }
    }
}
