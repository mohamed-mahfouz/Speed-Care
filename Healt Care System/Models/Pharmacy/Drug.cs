using System;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Healt_Care_System.Entities;

namespace Healt_Care_System.Models
{
    public class Drug
    {
        private MongoDBContext _context;
        private string _table;

        public Drug()
        {

            _context = new MongoDBContext();
            _table = "Drugs";
        }

        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("id")]
        public string DrugId { get; set; }

        [Required]
        [Display(Name = "Type")]
        [BsonElement("DrugTypeId")]
        public int DrugTypeId { get; set; }

        public DrugType DrugTypeRecord
        {
            get
            {

               return _context.LoadRecordByIdProperity<DrugType>("DrugTypes", DrugTypeId);
            }
        }

        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("concentration")]
        [Required]
        [Range(0,100)]
        public double? Concentration { get; set; }

        [BsonElement("quantity")]
        [Required]
        public int? Quantity { get; set; }

        [BsonElement("price")]
        [Required]
        public double? Price { get; set; }

        public string Title
        {
            get
            {
                return Id == Guid.Empty ? "New Drug" : "Edit Drug";
            }
        }
    }
}