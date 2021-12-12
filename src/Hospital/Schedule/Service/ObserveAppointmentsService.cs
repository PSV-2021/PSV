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
        private IAppointmentRepository AppointmentRepository { get; set; }

        public ObserveAppointmentsService(ObserveAppointmentsSqlRepository observeAppointmentsSqlRepository)
        {
            this.ObserveAppointmentsSqlRepository = observeAppointmentsSqlRepository;
            AppointmentRepository = observeAppointmentsSqlRepository;
        }
        public ObserveAppointmentsService(IAppointmentRepository iAppointmentRepository)
        {
            AppointmentRepository = iAppointmentRepository;
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

                if (a.StartTime.Day < DateTime.Now.Day + 3)
                    a.canCancel = false;
            }

            return appointments;
        }

        //CancelAppointments

        public bool CancelAppointment(int appointmentId)
        {
            Appointment appointment = AppointmentRepository.GetByAppointmentId(appointmentId);
            appointment.isCancelled = true;
            bool retVal = AppointmentRepository.Update(appointment);
            return retVal;
        }
    }
}
