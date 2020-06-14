using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{
    public class PopulateNurseDegrees
    {

        private MongoDBContext _context;
        private string _table;

        public PopulateNurseDegrees()
        {
            _context = new MongoDBContext();
            _table = "NurseDegrees";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<NurseDegree> Records()
        {
            return new List<NurseDegree>
           {
               new NurseDegree {Id=1 , Name="ممرض مساعد" },
               new NurseDegree {Id=2 , Name="ممرض" },
               new NurseDegree {Id=3 , Name="رئيس تمريض" },

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

        public IEnumerable<NurseDegree> GetRecords
        {
            get
            {
                return _context.LoadRecords<NurseDegree>(_table);
            }
        }

    }
}