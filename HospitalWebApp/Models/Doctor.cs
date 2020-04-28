using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorGender { get; set; }
        public int DoctorAge { get; set; }
        public string Qualification { get; set; }
        public int Experience { get; set; }

    }
}
