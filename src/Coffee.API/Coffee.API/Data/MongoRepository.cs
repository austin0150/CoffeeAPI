using Coffee.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Coffee.API.Data
{
    public class MongoRepository
    {

        private readonly IMongoDatabase _database;

        public MongoRepository (ICoffeeDatabaseConfiguration settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
        }

        public string InsertBrewType(BrewType type)
        {
            return "";
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
