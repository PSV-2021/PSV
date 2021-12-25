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

            Appointment appointment = new Appointment(1, new DateTime(2021, 12, 12, 8, 0, 0), 30, "", false, 1, 1, false);

            stubRepository.Setup(x => x.GetByAppointmentId(1)).Returns(appointment);

            stubRepository.Setup(x => x.Update(appointment)).Returns(true);

            return stubRepository.Object;
        }

        public static List<Appointment> CreateListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            Appointment appointment1 = new Appointment(1, new DateTime(2021, 12, 12, 8, 0, 0), 30, "", false, 1, 1, false);
            Appointment appointment2 = new Appointment(2, new DateTime(2021, 12, 12, 8, 30, 0), 30, "", false, 1, 2, false);
            Appointment appointment3 = new Appointment(2, new DateTime(2021, 12, 12, 9, 0, 0), 30, "", false, 1, 1, false);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);

            return appointments;
        }

    }
}
