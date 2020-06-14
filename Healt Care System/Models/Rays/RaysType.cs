using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models
{
    public class RaysType
    {
        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        [Required]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}