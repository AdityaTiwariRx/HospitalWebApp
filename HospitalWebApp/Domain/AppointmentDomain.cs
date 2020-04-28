using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalWebApp.Models;

namespace HospitalWebApp.Domain
{
    public class AppointmentDomain: BaseDomain
    {
        public List<Appointment> Get()
        {

            var reader = this.GetReader("select *from Appointments");
            var appointments = new List<Appointment>();
            while (reader.Read())
            {

                var assistant = new Appointment();
                assistant.AppointmentId = reader.GetInt32(0);
                assistant.PatientId = reader.GetInt32(1);
                assistant.DoctorId = reader.GetInt32(2);
                assistant.AppointmentDateTime = reader.GetDateTime(3);
                assistant.Description = reader.GetString(4);
                appointments.Add(assistant);


            }
            return appointments;
        }


        public void Add(Appointment appointment)
        {
            this.ExecuteNonQuery($"insert into Appointments values ('{appointment.PatientId}',{appointment.DoctorId},'{appointment.AppointmentDateTime}','{appointment.Description}')");
        }
        public void Update(Appointment appointment)
        {
            this.ExecuteNonQuery($"update Appointments set PatientId='{appointment.PatientId}',DoctorId='{appointment.DoctorId}',AppointmentDateTime='{appointment.AppointmentDateTime}',Description='{appointment.Description}' where AppointmentId = {appointment.AppointmentId}");
        }
        public void Delete(int id)
        {
            this.ExecuteNonQuery($"delete from Assistants where AssistantId = {id}");
        }

    }
}
