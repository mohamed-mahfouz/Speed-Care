using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Healt_Care_System.Models
{
    public class DoctorDegree
    {
        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string  Name { get; set; }
        

        
        

    }
}