using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace Healt_Care_System.Models
{
    public class RoomType
    {

        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }
    }
}