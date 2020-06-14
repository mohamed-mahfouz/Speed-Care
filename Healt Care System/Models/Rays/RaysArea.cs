using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models
{
    public class RaysArea
    {

        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        public int Id { get; set; }
      
        [BsonElement("name")]     
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("RaysTypeId")]
        public int RaysTypeId { get; set; }

    }
}