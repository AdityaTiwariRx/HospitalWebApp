using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApp.Models;

namespace HospitalWebApp.Domain
{
    public class PatientDrugDetailDomain : BaseDomain
    {
        public List<PatientDrugDetails> Get()
        {

            var reader = this.GetReader("select *from PatientDrugDetails");
            var patientDrugDetails = new List<PatientDrugDetails>();
            while (reader.Read())
            {

                var patientDrugDetail = new PatientDrugDetails();
                patientDrugDetail.PatientId = reader.GetInt32(0);
                patientDrugDetail.MorningDrugId = reader.GetInt32(1);
                patientDrugDetail.AfternoonDrugId = reader.GetInt32(2);
                patientDrugDetail.EveningDrugId = reader.GetInt32(3);
                patientDrugDetails.Add(patientDrugDetail);


            }
            return patientDrugDetails;
        }

        public void Add(PatientDrugDetails patientDrugDetails)
        {
            this.ExecuteNonQuery($"insert into PatientDrugDetails values ('{patientDrugDetails.MorningDrugId}',{patientDrugDetails.AfternoonDrugId},'{patientDrugDetails.EveningDrugId}')");
        }
        public void Update(PatientDrugDetails patientDrugDetails)
        {
            this.ExecuteNonQuery($"update PatientDrugDetails set MorningDrugId='{patientDrugDetails.MorningDrugId}',AfternoonDrugId='{patientDrugDetails.AfternoonDrugId}',EveningDrugId='{patientDrugDetails.EveningDrugId} where PatientId = {patientDrugDetails.PatientId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from PatientDrugDetails where PatientId = {id}");
        }





    }
}