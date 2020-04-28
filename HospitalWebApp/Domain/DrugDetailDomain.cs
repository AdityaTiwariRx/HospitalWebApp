using System;
using System.Collections.Generic;
using System.Linq;
using HospitalWebApp.Models;
using System.Threading.Tasks;


namespace HospitalWebApp.Domain
{
    public class DrugDetailDomain: BaseDomain
    {
        public List<DrugDetails> Get()
        {

            var reader = this.GetReader("select * from DrugDetails");
            var drugDetails = new List<DrugDetails>();
            while (reader.Read())
            {

                var drugDetail = new DrugDetails();
                drugDetail.DrugId = reader.GetInt32(0);
                drugDetail.DrugName = reader.GetString(1);
                drugDetail.DrugDescription = reader.GetString(2);
                drugDetails.Add(drugDetail);


            }
            return drugDetails;
        }
        public void Add(DrugDetails drugDetail)
        {
            this.ExecuteNonQuery($"insert into DrugDetails values ('{drugDetail.DrugName}','{drugDetail.DrugDescription}')");
        }
        public void Update(DrugDetails drugDetail)
        {
            this.ExecuteNonQuery($"update DrugDetails set DrugName='{drugDetail.DrugName},DrugDescription='{drugDetail.DrugDescription}'");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from DrugDetails where DrugDetailId = {id}");
        }





    }
}
