using Healt_Care_System.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Models
{
    public class Rays
    {

        private MongoDBContext _context;

        public Rays()
        {
            _context = new MongoDBContext();
        }

        [BsonId]
        public Guid _Id { get; set; }

        [BsonElement("id")]
        [Required]
        public string Id { get; set; }

        [BsonElement("typeId")]
        [Display(Name = "Type")]
        [Required]
        public int TypeId { get; set; }

        [BsonElement("type")]
        [Required]
        public string TypeName
        {

            get
            {

                var record = _context.LoadRecordByIdProperity<RaysType>("RaysTypes", TypeId);
                var name = record.Name;
                return name;

            }
        }

        [Required]
        [Display(Name ="Patient")]
        public string  PatientName { get; set; }

        [BsonElement("areaId")]
        [Display(Name = "Area")]
        [Required]
        public int AreaId { get; set; }

        [BsonElement("price")]
        [Required]
        public double Price
        {
            get
            {

               var record = _context.LoadRecordByIdProperity<RaysArea>("RaysAreas", AreaId);
               var price = record.Price;
               return price;
            }
        }


        [BsonElement("areaName")]
        public string AreaName
        {
           get
            {

                var record = _context.LoadRecordByIdProperity<RaysArea>("RaysAreas", AreaId);
                var name = record.Name;
                return name;
            }
        }
    }
}