using Healt_Care_System.Models.MedicalTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Entities.MedicalTests
{
    public class PopulateMedicalType
    {
        private MongoDBContext _context;
        private string table;

        public PopulateMedicalType()
        {
            _context = new MongoDBContext();
            table = "MedicalType";

            // Populate Table in DB and not every time Populated it
            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<MedicalType> Records()
        {
            return new List<MedicalType>
            {
                new MedicalType { Id=1,  Type="صوره دم كامله", Price=500, MedicalTestId=1},
                new MedicalType { Id=2,  Type="سرعة الترسيب", Price=400, MedicalTestId=1},
                new MedicalType { Id=3,  Type="النقرس", Price=300, MedicalTestId=1},
                new MedicalType { Id=4,  Type="البولينا", Price=200, MedicalTestId=1},
                new MedicalType { Id=5,  Type="بول وبراز", Price=100, MedicalTestId=1},
                new MedicalType { Id=6,  Type="سكر صايم", Price=500, MedicalTestId=2},
                new MedicalType { Id=7,  Type="الهيموجلوبين", Price=400, MedicalTestId=2},
                new MedicalType { Id=8,  Type="الكولسترول", Price=300, MedicalTestId=2},
                new MedicalType { Id=9,  Type="سكر الدم فاطر", Price=200, MedicalTestId=2},
                new MedicalType { Id=10, Type="اختبار منحنى السكر", Price=100, MedicalTestId=2},
                new MedicalType { Id=11, Type="البولينا", Price=500, MedicalTestId=3},
                new MedicalType { Id=12, Type="الكرياتنين", Price=500, MedicalTestId=3},
                new MedicalType { Id=13, Type="النقرس", Price=500, MedicalTestId=3},
                new MedicalType { Id=14, Type="الصوديوم", Price=500, MedicalTestId=3},
                new MedicalType { Id=15, Type="البوتاسيوم", Price=500, MedicalTestId=3},
                new MedicalType { Id=16, Type="البروتين الكلى", Price=400, MedicalTestId=4},
                new MedicalType { Id=17, Type="الفوسفاتاز القلوية", Price=300, MedicalTestId=4},
                new MedicalType { Id=18, Type="انزيمات الكبد", Price=200, MedicalTestId=4},
                new MedicalType { Id=19, Type="السيوله", Price=100, MedicalTestId=4},
                new MedicalType { Id=20, Type="توربونين", Price=200, MedicalTestId=5},
                new MedicalType { Id=21, Type="CK(MB-Total SGOT-LDH)", Price=500, MedicalTestId=5},
            };
        }

        public void Populate()
        {
            var records = Records();
            foreach (var record in records)
            {
                _context.InsertRecord(table, record);
            }
        }

        public IEnumerable<MedicalType> GetRecords
        {
            get
            {
              return _context.LoadRecords<MedicalType>(table);
            }
        }

    }
}