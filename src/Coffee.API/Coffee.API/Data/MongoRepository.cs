using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Coffee.API.Data
{
    public class MongoRepository : IMongoRepository
    {

        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<BrewType> _brewTypes;

        public MongoRepository (ICoffeeDatabaseConfiguration settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _brewTypes = _database.GetCollection<BrewType>(settings.BrewTypeCollectoionName);
        }

        public string InsertBrewType(BrewType type)
        {
            _brewTypes.InsertOne(type);
            return type.Name;
        }

        public BrewType GetBrewType(string id)
        {
            return null;
        }

        public List<BrewType> SearchBrewType(string searchTerm, string searchBy)
        {
            return null;
        }

    }
}
