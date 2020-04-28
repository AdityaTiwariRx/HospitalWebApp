using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public string PatientAddress { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string PatientDiseases { get; set; }

    }
}
