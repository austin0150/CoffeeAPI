using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Models
{
    public class CoffeeDatabaseConfiguration :ICoffeeDatabaseConfiguration
    {
        public string BrewTypeCollectoionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICoffeeDatabaseConfiguration
    {
        public string BrewTypeCollectoionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
