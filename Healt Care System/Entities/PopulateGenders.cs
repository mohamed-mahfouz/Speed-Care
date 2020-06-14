using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;


namespace Healt_Care_System.Entities
{
    public class PopulateGenders
    {
        private MongoDBContext _context;
        private string _table;

        public PopulateGenders()
        {
            _context = new MongoDBContext();
            _table = "Genders";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<Gender> Records()
        {
            return new List<Gender>
           {
               new Gender {Id=1 , Name="Male" },
               new Gender {Id=2 , Name="Female" }

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

        public IEnumerable<Gender> GetRecords
        {
            get
            {
                return _context.LoadRecords<Gender>(_table);
            }
        }
    }
}