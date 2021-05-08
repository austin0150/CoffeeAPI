using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Reflection;

namespace Coffee.API.Data
{
    public class MongoRepository : IMongoRepository
    {

        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<BrewType> _brewTypes;
        private readonly IMongoCollection<BeanType> _beanTypes;

        public MongoRepository (ICoffeeDatabaseConfiguration settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _brewTypes = _database.GetCollection<BrewType>(settings.BrewTypeCollectoionName);

        }


        //BREW TYPE FUNCTIONS

        public BrewType InsertBrewType(BrewType type)
        {
            _brewTypes.InsertOne(type);
            return type;
        }

        public async Task<BrewType> UpdateBrewType(BrewType type)
        {
            var replaceOneResult = await _brewTypes.ReplaceOneAsync(doc => doc.Id == type.Id,type);
            if (replaceOneResult.IsAcknowledged)
            {
                return type;
            }
            else 
            {
                return null;
            }

        }

        public async Task<BrewType> GetBrewType(string name)
        {
            var filter = Builders<BrewType>.Filter.Eq(brewType => brewType.Name, name);
            return await _brewTypes.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<BrewType> GetBrewTypeByID(string id)
        {

            var filter = Builders<BrewType>.Filter.Eq(brewType => brewType.Id , id);
            return await _brewTypes.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<BrewType>> SearchBrewTypeName(string name)
        {
            var filter = Builders<BrewType>.Filter.Where(brewType => brewType.Name.Contains(name));
            return await _brewTypes.Find(filter).ToListAsync();

        }
        public async Task<List<BrewType>> SearchBrewTypeDescription(string desc)
        {
            var filter = Builders<BrewType>.Filter.Where(brewType => brewType.Description.Contains(desc));
            return await _brewTypes.Find(filter).ToListAsync();

        }


        //BEANTYPE FUNCTIONS

        public BeanType InsertBeanType(BeanType type)
        {
            _beanTypes.InsertOne(type);
            return type;
        }
    }
}
