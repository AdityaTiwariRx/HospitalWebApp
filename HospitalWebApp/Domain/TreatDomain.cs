using HospitalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApp.Domain
{
    public class TreatDomain: BaseDomain
    {
        public List<vTreat> Get()
        {

            var reader = this.GetReader("select *from vTreat");
            var vTreats = new List<vTreat>();
            while (reader.Read())
            {

                var vTreat = new vTreat();
                vTreat.DoctorName = reader.GetString(0);
                vTreat.PatientName = reader.GetString(1);
                vTreat.DepartmentName = reader.GetString(2);
                
                vTreats.Add(vTreat);


            }
            return vTreats;
        }

        public void Add(Treat treat)
        {
            this.ExecuteNonQuery($"insert into Treats values ('{treat.DoctorId}','{treat.PatientId}',{treat.DepartmentId}')");
        }
        public void Update(Treat treat)
        {
            this.ExecuteNonQuery($"update s set DoctorId='{treat.DoctorId}',PatientId='{treat.PatientId}',DepartmentId='{treat.DepartmentId}' where TreatmentId = {treat.TreatmentId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Treats where TreatmentId = {id}");
        }




    }
}








