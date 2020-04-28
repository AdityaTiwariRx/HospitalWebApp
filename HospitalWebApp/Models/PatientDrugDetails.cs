using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class PatientDrugDetails
    {
        public int PatientId { get; set; }
        public int MorningDrugId { get; set; }
        public int AfternoonDrugId { get; set; }
        public int EveningDrugId { get; set; }


    }
}
