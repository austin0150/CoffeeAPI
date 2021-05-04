using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Data
{
    public interface IMongoRepository
    {
        public string InsertBrewType(BrewType type);

        public BrewType GetBrewType(string id);
    }
}
