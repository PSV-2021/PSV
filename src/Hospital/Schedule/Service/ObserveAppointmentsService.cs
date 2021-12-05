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
            return ObserveAppointmentsSqlRepository.GetById(id);
        }
    }
}
