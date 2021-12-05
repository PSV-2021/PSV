using Hospital.Schedule.Model;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class RecommendedAppointmentSqlRepository : IAppointmentRepository
    {
        private MyDbContext context;

        public RecommendedAppointmentSqlRepository(MyDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public Appointment GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Appointment newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Appointment editedObject)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> Get(int doctorId, DateTime date)
        {
            return GetAll().Where(a => a.DoctorId.Equals(doctorId) && a.StartTime.Date.CompareTo(date.Date) == 0).ToList();
        }
    }
}
