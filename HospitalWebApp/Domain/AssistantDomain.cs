using System;
using System.Collections.Generic;
using System.Linq;
using HospitalWebApp.Models;
using System.Threading.Tasks;

namespace HospitalWebApp.Domain
{
    public class AssistantDomain : BaseDomain
    {
        public List<Assistant> Get()
        {

            var reader = this.GetReader("select *from Assistants");
            var assistants = new List<Assistant>();
            while (reader.Read())
            {

                var assistant = new Assistant();
                assistant.AssistantId = reader.GetInt32(0);
                assistant.AssistantName = reader.GetString(1);
                assistant.AssistantGender = reader.GetString(2);
                assistant.AssistantAge = reader.GetInt32(3);
                assistant.DepartmentId = reader.GetInt32(4);
                assistants.Add(assistant);


            }
            return assistants;
        }
        public void Add(Assistant assistant)
        {
            this.ExecuteNonQuery($"insert into Assistants values ('{assistant.AssistantName}',{assistant.AssistantGender},'{assistant.AssistantAge}','{assistant.DepartmentId}')");
        }
        public void Update(Assistant assistant)
        {
            this.ExecuteNonQuery($"update Assistants set AssistantName='{assistant.AssistantName}',AssistantGender='{assistant.AssistantGender}',AssistantAge='{assistant.AssistantAge}',DepartmentId='{assistant.DepartmentId}' where AssistantId = {assistant.AssistantId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Assistants where AssistantId = {id}");
        }


    }
}