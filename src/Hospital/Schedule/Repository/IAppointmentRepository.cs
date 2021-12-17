using Hospital.Schedule.Model;
using System;
using System.Collections.Generic;

namespace Hospital.Schedule.Repository
{
    public interface IAppointmentRepository: IGenericRepository<Appointment, int>
    {
        public List<Appointment> Get(int doctorId, DateTime date);
        public void Create(Appointment appointment);
        public Appointment GetByAppointmentId(int appointmentId);

    }
}
