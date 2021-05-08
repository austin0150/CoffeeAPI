using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffee.API.Models
{
    public class BrewType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BrewTime { get; set; } //Minutes
        public double CoffeeWaterRatio { get; set; }
        public string GrindSize { get; set; }
    }
}
