using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{

    public class PopulateDoctorDegrees
    {
        private MongoDBContext _context;
        private string _table;
      
        public PopulateDoctorDegrees()
        {
            _context = new MongoDBContext();
            _table = "DoctorDegrees";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<DoctorDegree> Records()
        {
            return new List<DoctorDegree>
           {
               new DoctorDegree {Id=1 , Name="طبيب" },
               new DoctorDegree {Id=2 , Name="طبيب أول" },
               new DoctorDegree {Id=3 , Name="استشاري" },

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

        public IEnumerable<DoctorDegree> GetRecords
        {
            get
            {
                return _context.LoadRecords<DoctorDegree>(_table);
            }
        }
    }
}                  
            
            
        
     


         
