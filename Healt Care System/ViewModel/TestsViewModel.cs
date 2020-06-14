using Healt_Care_System.Models.MedicalTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healt_Care_System.ViewModel
{
    public class TestsViewModel
    {
        public Tests Tests { get; set; }
        public IEnumerable<MedicalTest> MedicalTest { get; set; }
    }
}