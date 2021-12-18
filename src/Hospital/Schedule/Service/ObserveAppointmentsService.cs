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
        private Appointment Appointment = new Appointment();

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

            return Appointment.StatusAppointment(appointments);
        }

        //CancelAppointments

        public bool CancelAppointment(int appointmentId)
        {
            Appointment appointment = AppointmentRepository.GetByAppointmentId(appointmentId);
            appointment.SetCancel(appointment);
            bool retVal = AppointmentRepository.Update(appointment);
            return retVal;
        }
    }
}
