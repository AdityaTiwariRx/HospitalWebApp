using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApp.Models;

namespace HospitalWebApp.Domain
{
    public class DoctorDomain: BaseDomain
    {
        public List<Doctor> Get()
        {

            var reader = this.GetReader("select *from doctors");
            var doctors = new List<Doctor>();
            while (reader.Read())
            {

                var doctor = new Doctor();
                doctor.DoctorId = reader.GetInt32(0);
                doctor.DoctorName = reader.GetString(1);
                doctor.DoctorGender = reader.GetString(2);
                doctor.DoctorAge = reader.GetInt32(3);
                doctor.Qualification = reader.GetString(4);
                doctor.Experience = reader.GetInt32(5);
                doctors.Add(doctor);


            }
            return doctors;
        }

        public void Add(Doctor doctor)
        {
            this.ExecuteNonQuery($"insert into Doctors values ('{doctor.DoctorName}','{doctor.DoctorGender}','{doctor.DoctorAge}','{doctor.Qualification}','{doctor.Experience}')");
        }
        public void Update(Doctor doctor)
        {
            this.ExecuteNonQuery($"update Doctors set DoctorName='{doctor.DoctorName}',DoctorGender='{doctor.DoctorGender}',DoctorAge='{doctor.DoctorAge}',Qualification='{doctor.Qualification}',Experience='{doctor.Experience}'");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Doctors where DoctortId = {id}");
        }







    }
}
