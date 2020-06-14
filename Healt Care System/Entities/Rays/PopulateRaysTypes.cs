using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{
    public class PopulateRaysTypes
    {

        private MongoDBContext _context;
        private string _table;

        public PopulateRaysTypes()
        {

            _context = new MongoDBContext();
            _table = "RaysTypes";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<RaysType> Records()
        {
            return new List<RaysType>
            {

                new RaysType {Id=1 , Name="أشعة سينية" },
                new RaysType {Id=2 , Name="أشعة مقطعية" },
                new RaysType {Id=3 , Name="أشعة صبغة" },
                new RaysType {Id=4 , Name="أشعة رنين مغناطيسي" }
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

        public IEnumerable<RaysType> GetRecords
        {
            get
            {
                return _context.LoadRecords<RaysType>(_table);
            }
        }
    }
}