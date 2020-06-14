using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;

namespace Healt_Care_System.Entities
{
    public class PopulateDrugTypes
    {

        private MongoDBContext _context;
        private string _table;

        public PopulateDrugTypes()
        {
            _context = new MongoDBContext();
            _table = "DrugTypes";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<DrugType> Records()
        {
            return new List<DrugType>
           {
               new DrugType {Id=1 , Name="شراب"  },
               new DrugType {Id=2 , Name="أقراص"  },
               new DrugType {Id=3 , Name="حقن"  },
               new DrugType {Id=4 , Name="محلول"  },
               new DrugType {Id=5 , Name="لبوس"  },

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

        public IEnumerable<DrugType> GetRecords
        {
            get
            {
                return _context.LoadRecords<DrugType>(_table);
            }
        }


    }
}