using Hospital.Schedule.Model;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class ObserveAppointmentsSqlRepository : IAppointmentRepository
    {
        private MyDbContext context;

        public ObserveAppointmentsSqlRepository(MyDbContext context)
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

        internal List<Appointment> GetById(int id)
        {
            return context.Appointments.Where(s => s.PatientId == id).ToList();
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
            context.Appointments.Update(editedObject);
            context.SaveChanges();
            return true;
        }

        public Appointment GetByAppointmentId(int appointmentId)
        {
            return context.Appointments.Find(appointmentId);
        }

        public List<Appointment> Get(int doctorId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Create(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
