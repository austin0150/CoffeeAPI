using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Data
{
    public interface IMongoRepository
    {
        public BrewType InsertBrewType(BrewType type);
        public Task<BrewType> UpdateBrewType(BrewType type);
        public Task<BrewType> GetBrewType(string name);
        public Task<BrewType> GetBrewTypeByID(string id);
        public Task<List<BrewType>> SearchBrewTypeDescription(string desc);
        public Task<List<BrewType>> SearchBrewTypeName(string name);
    }
}
