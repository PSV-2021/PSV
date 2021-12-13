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
    [Trait("Type", "UnitTest")]
    public class CancelAppointmentsTests
    {
        [Fact]
        public void Cancel_appointment()
        {
            var appointmentStubRepository = CreateAppointmentStubRepository();
            ObserveAppointmentsService service = new ObserveAppointmentsService(appointmentStubRepository);
            bool b = service.CancelAppointment(1);
            b.ShouldBeTrue();
        }

        public static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();

            Appointment appointment = new Appointment
            {
                Id = 1,
                StartTime = new DateTime(2021, 12, 12, 8, 0, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 1,
                isCancelled = false
            };

            stubRepository.Setup(x => x.GetByAppointmentId(1)).Returns(appointment);

            stubRepository.Setup(x => x.Update(appointment)).Returns(true);

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

    }
}
