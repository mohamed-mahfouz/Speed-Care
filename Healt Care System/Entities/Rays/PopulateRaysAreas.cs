using System.Collections.Generic;
using System.Linq;
using Healt_Care_System.Models;


namespace Healt_Care_System.Entities
{
    public class PopulateRaysAreas
    {

        private MongoDBContext _context;
        private string _table;

        public PopulateRaysAreas()
        {
            _context = new MongoDBContext();
            _table = "RaysAreas";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<RaysArea> Records()
        {
            return new List<RaysArea>
            {

                new RaysArea {Id=1 , Name="جمجمة" , Price=150 , RaysTypeId=1 },
                new RaysArea {Id=2 , Name="عمود فقري" , Price=300 , RaysTypeId=1},
                new RaysArea {Id=3 , Name="حوض وأطراف سفلية" , Price=250 , RaysTypeId=1 },
                new RaysArea {Id=4 , Name="كتف وأطراف علوية" , Price=100 , RaysTypeId=1 },
                new RaysArea {Id=5 , Name="صدر وبطن" , Price=90 , RaysTypeId=1 },
                new RaysArea {Id=6 , Name="وجه وفك" , Price=100 , RaysTypeId=1 },
                new RaysArea {Id=7 , Name="مخ" , Price=320 , RaysTypeId=2},
                new RaysArea {Id=8 , Name="أذن" , Price=400 , RaysTypeId=2},
                new RaysArea {Id=9 , Name="بطن" , Price=450 , RaysTypeId=2},
                new RaysArea {Id=10, Name="عظام الوجه" , Price=350 , RaysTypeId=2},
                new RaysArea {Id=11, Name="مخ" , Price = 1400 , RaysTypeId=3},
                new RaysArea {Id=12, Name="رقبة وأذن" , Price = 900 , RaysTypeId=3 },
                new RaysArea {Id=13, Name="صدر" , Price = 100 , RaysTypeId=3 },
                new RaysArea {Id=14, Name="أطراف علوية" , Price = 1200 , RaysTypeId=3 },
                new RaysArea {Id=15, Name="أمعاء" , Price=380 , RaysTypeId=4 },
                new RaysArea {Id=16, Name="قولون" , Price=400 , RaysTypeId=4 },
                new RaysArea {Id=17, Name="مرئ" , Price=450 , RaysTypeId=4 },
                new RaysArea {Id=18, Name="مسالك بولية" , Price=340 , RaysTypeId=4  }
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

        public IEnumerable<RaysArea> GetRecords
        {
            get
            {
                return _context.LoadRecords<RaysArea>(_table);
            }
        }
    }
}