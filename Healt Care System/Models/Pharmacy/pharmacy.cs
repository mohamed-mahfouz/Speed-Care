using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models
{
    public class pharmacy
    {

        [BsonId]
        public Guid _Id { get; set; }
     
        [BsonElement("id")]
        public string Id { get; set; }
        
        [BsonElement("patient")]
        public string Patient { get; set; }
       
        [BsonElement("price")]
        public double? Price { get; set; }

        [BsonElement("notes")]    
        public string Notes { get; set; }

        [BsonElement("drugs")]     
        public string Drugs { get; set; }

        public string Title
        {
            get
            {
                return _Id == Guid.Empty ? "New Invoice" : "Edit Ivoice";
            }
        }

    }
}