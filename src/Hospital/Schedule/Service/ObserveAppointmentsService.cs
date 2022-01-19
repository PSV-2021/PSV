using Hospital.DTO;
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

        //ObserveReport
        public Appointment GetById(int id)
        {
            Appointment appointment = ObserveAppointmentsSqlRepository.GetByAppointmentId(id);
            return appointment;
        }

        public static ReportDTO ReportDTO(Appointment appointment)
        {
            ReportDTO dto = new ReportDTO
            {
                 Id = appointment.Id,
                 StartTime = appointment.StartTime,
                 ApointmentDescription = appointment.ApointmentDescription,
                 DoctorId = appointment.DoctorId,
                 PatientId = appointment.PatientId
            };

            return dto;
        }
    }
}
