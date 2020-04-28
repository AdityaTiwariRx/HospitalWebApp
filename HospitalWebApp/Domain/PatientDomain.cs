using HospitalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Domain
{
    public class PatientDomain: BaseDomain
    {
        public List<Patient> Get()
        {

            var reader = this.GetReader("select *from Patients");
            var patients = new List<Patient>();
            while (reader.Read())
            {

                var patient = new Patient();
                patient.PatientId = reader.GetInt32(0);
                patient.PatientName = reader.GetString(1);
                patient.PatientAddress = reader.GetString(2);
                patient.PatientAge = reader.GetInt32(3);
                patient.PatientGender = reader.GetString(4);
                patient.PatientDiseases = reader.GetString(5);
                patients.Add(patient);


            }
            return patients;
        }

        public void Add(Patient patient)
        {
            this.ExecuteNonQuery($"insert into Patients values ('{patient.PatientName}','{patient.PatientAddress}',{patient.PatientAge},'{patient.PatientGender}','{patient.PatientDiseases}')");
        }
        public void Update(Patient patient)
        {
            this.ExecuteNonQuery($"update Patients set PatientName='{patient.PatientName}',PatientAddress='{patient.PatientAddress}',PatientAge='{patient.PatientAge}',PatientGender='{patient.PatientGender}',PatientDiseases='{patient.PatientDiseases}' where PatientId = {patient.PatientId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Patients where PatientId = {id}");
        }




    }
}
