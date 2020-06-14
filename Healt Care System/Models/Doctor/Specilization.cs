using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Healt_Care_System.Models
{
    public class specilization
    {
        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public int Price { get; set; }



    }
}