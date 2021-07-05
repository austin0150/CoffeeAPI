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
        public Task<bool> DeleteBrewType(BrewType type);
        public BeanType InsertBeanType(BeanType type);
        public Task<BeanType> GetBeanType(string name);
        public Task<BeanType> UpdateBeanType(BeanType type);
        public Task<bool> DeleteBeanType(BeanType type);
    }
}
