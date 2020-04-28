using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApp.Models;

namespace HospitalWebApp.Domain
{
    public class DepartmentDomain:BaseDomain
    {

        public List<Department> Get()
        {

            var reader = this.GetReader("select *from Departments");
            var departments = new List<Department>();
            while (reader.Read())
            {

                var department = new Department();
                department.DepartmentId = reader.GetInt32(0);
                department.DepartmentName = reader.GetString(1);
                departments.Add(department);


            }
            return departments;
        }

        public void Add(Department department)
        {
            this.ExecuteNonQuery($"insert into Departments values ('{department.DepartmentName}')");
        }
        public void Update(Department department)
        {
            this.ExecuteNonQuery($"update Departments set DepartmentName='{department.DepartmentName}'");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Departments where DepartmentId = {id}");
        }


    }
}
