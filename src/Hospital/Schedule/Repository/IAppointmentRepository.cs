using Hospital.Schedule.Model;
using System.Collections.Generic;

namespace Hospital.Schedule.Repository
{
    public interface IAppointmentRepository : IGenericRepository<Appointment, int>
    {
        public Appointment GetByAppointmentId(int appointmentId);
    }
}
