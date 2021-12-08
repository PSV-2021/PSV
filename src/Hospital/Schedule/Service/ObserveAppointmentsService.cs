using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public class ObserveAppointmentsService
    {
        private ObserveAppointmentsSqlRepository ObserveAppointmentsSqlRepository;

        public ObserveAppointmentsService(ObserveAppointmentsSqlRepository observeAppointmentsSqlRepository)
        {
            this.ObserveAppointmentsSqlRepository = observeAppointmentsSqlRepository;
        }
        public List<Appointment> GetAppointmentsById(int id)
        {
            List<Appointment> appointments = ObserveAppointmentsSqlRepository.GetById(id);

            foreach(Appointment a in appointments)
            {
                if (a.isCancelled)
                    a.Status = AppointmentStatus.CANCELLED;
                else if (a.StartTime < DateTime.Now)
                    a.Status = AppointmentStatus.DONE;
                else if (a.StartTime > DateTime.Now)
                    a.Status = AppointmentStatus.UPCOMING;
            }

            return appointments;
        }
    }
}
