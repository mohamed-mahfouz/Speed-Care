using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{
    public class PopulateSpecilizations
    {
        private MongoDBContext _context;
        private string _table;


        public PopulateSpecilizations()
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
               new specilization {Id=1 , Name="أطفال", Price=30 },
               new specilization {Id=2 , Name="أنف وأذن وحنجرة", Price=20},
               new specilization {Id=3 , Name="توليد ونسائيات", Price=25 },
               new specilization {Id=4 , Name="جهاز بولي", Price=35 },
               new specilization {Id=5 , Name="طوارئ" , Price=45},
               new specilization {Id=6 , Name="عيون", Price=40 },
               new specilization {Id=7 , Name="باطنة", Price=50},
               new specilization {Id=8 , Name="جراحة" , Price=55 }

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

       public IEnumerable<specilization> GetRecords
        {
             get
            {
                return _context.LoadRecords<specilization>(_table);
            }       
        }
    }
}  
