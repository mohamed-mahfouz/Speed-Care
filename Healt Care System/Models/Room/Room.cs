using System;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using Healt_Care_System.Entities;

namespace Healt_Care_System.Models
{
	public class Room
	{
		private MongoDBContext _context;
		private string _table;

		public Room()
		{
			_context = new MongoDBContext();
			_table = "Rooms";
		}

		[BsonId]
		public Guid Id { get; set; }

		[BsonElement("id")]
		[Display(Name = "Id")]
		public string RoomId { get; set; }

		[Required]
		[Display(Name ="Type")]
		[BsonElement("roomTypeId")]
		public int RoomTypeId { get; set; }

		[Required]
		[BsonElement("floor")]
		[Range(1,5)]
		public int? Floor { get; set; }

		public RoomType RoomTypeRecord
		{
			get
			{
			   return _context.LoadRecordByIdProperity<RoomType>("RoomTypes", RoomTypeId);
			}
		}

		public string Title
		{
			get
			{
				return Id == Guid.Empty ? "New Room" : "Edit Room";
			}
		}

	}
}