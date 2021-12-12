using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace HospitalApiTests.Unit
{
    public class CancelAppointmentsTests
    {
        [Fact]
        public void Cancel_appointment()
        {
            var appointmentStubRepository = CreateAppointmentStubRepository();
            ObserveAppointmentsService service = new ObserveAppointmentsService(appointmentStubRepository);
            bool b = service.CancelAppointment(1);
            b.ShouldBeFalse();
        }

        public static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();
            var appointmentCancel = CreateAppointment();

            stubRepository.Setup(x => x.GetByAppointmentId(It.IsAny<int>())).Returns(
                (int id) =>
                appointments.Where(a => a.Id == id).FirstOrDefault());

            stubRepository.Setup(x => x.Update(appointmentCancel)).Returns(false);

            return stubRepository.Object;
        }

        public static List<Appointment> CreateListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            Appointment appointment1 = new Appointment
            {
                Id = 1,
                StartTime = new DateTime(2021, 12, 12, 8, 0, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 1,
                isCancelled = false
            };

            Appointment appointment2 = new Appointment
            {
                Id = 2,
                StartTime = new DateTime(2021, 12, 12, 8, 30, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 2,
                isCancelled = false
            };

            Appointment appointment3 = new Appointment
            {
                Id = 3,
                StartTime = new DateTime(2021, 12, 12, 9, 0, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 1,
                isCancelled = false
            };

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);

            return appointments;
        }

        public static Appointment CreateAppointment()
        {
            return new Appointment
            {
                Id = 1,
                StartTime = new DateTime(2021, 12, 12, 8, 0, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 1,
                isCancelled = true
            };
        }
    }
}
