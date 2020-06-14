using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{
    public class PopulateDepartments
    {
        private MongoDBContext _context;
        private string _table;


        public PopulateDepartments()
        {
            _context = new MongoDBContext();
            _table = "specilizations";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<specilization> Records()
        {
            return new List<specilization>
           {
               new specilization {Id=1 , Name="أطفال" },
               new specilization {Id=2 , Name="أنف وأذن وحنجرة"},
               new specilization {Id=3 , Name="توليد ونسائيات" },
               new specilization {Id=4 , Name="جهاز بولي" },
               new specilization {Id=5 , Name="طوارئ" },
               new specilization {Id=6 , Name="عيون" },
               new specilization {Id=7 , Name="باطنة" },
               new specilization {Id=8 , Name="جراحة" }

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

       public IEnumerable<Department> GetRecords
        {
             get
            {
                return _context.LoadRecords<Department>(_table);
            }       
        }
    }
}  
