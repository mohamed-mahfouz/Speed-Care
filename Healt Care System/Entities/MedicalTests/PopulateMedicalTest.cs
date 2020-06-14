using Healt_Care_System.Models.MedicalTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healt_Care_System.Entities.MedicalTests
{
    public class PopulateMedicalTest
    {
        private MongoDBContext _context;
        private string table;

        public PopulateMedicalTest()
        {
            _context = new MongoDBContext();
            table = "MedicalTest";

            if (GetRecords.Count() == 0)
                Populate();
        }

        private IEnumerable<MedicalTest> Records()
        {
            return new List<MedicalTest>
            {
                new MedicalTest { Id=1, Name="الفحص الدورى الشامل"},
                new MedicalTest { Id=2, Name="تحاليل السكر"},
                new MedicalTest { Id=3, Name="وظائف الكلى"},
                new MedicalTest { Id=4, Name="وظائف الكبد"},
                new MedicalTest { Id=5, Name="تحاليل القلب"},

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

        public IEnumerable<MedicalTest> GetRecords
        {
            get
            {
              return _context.LoadRecords<MedicalTest>(table);
            } 
        }


    }
}