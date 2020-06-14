using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{
    public class PopulateRoomTypes
    {
        private MongoDBContext _context;
        private string _table;

        public PopulateRoomTypes()
        {
            _context = new MongoDBContext();
            _table = "RoomTypes";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<RoomType> Records()
        {
            return new List<RoomType>
           {
               new RoomType {Id=1 , Name="استقبال"  },
               new RoomType {Id=2 , Name="عناية مركزة"  },
               new RoomType {Id=3 , Name="اقامة"  },
               new RoomType {Id=4 , Name="عادية"  },
               new RoomType {Id=5 , Name="أشعة"  },
               new RoomType {Id=6 , Name="تحاليل"  }
            };
        }

        public void Populate()
        {
            var records = Records();
            foreach (var record in records)
            {
                _context.InsertRecord(_table, record);

            }

        }

        public IEnumerable<RoomType> GetRecords
        {
            get
            {
                return _context.LoadRecords<RoomType>(_table);
            }
        }
    }
}