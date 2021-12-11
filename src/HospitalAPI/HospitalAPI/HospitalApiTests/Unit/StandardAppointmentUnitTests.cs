using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hospital.Schedule.Repository;
using Moq;
using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Shouldly;

namespace HospitalApiTests.Unit
{
    public class StandardAppointmentUnitTests
    {

        [Theory]
        [MemberData(nameof(Data))]
        public void Appointment_id_exist_or_doesnt_exist(DateTime timeofAppointment, bool expectedValue)
        {
            var appointmentStubRepository = new Mock<IAppointmentRepository>();
            var appointmentService = new AppointmentService(appointmentStubRepository.Object);
            List<Appointment> appointments = CreateAppointments();

            appointmentStubRepository.Setup(s => s.GetAll()).Returns(appointments);

            AppointmentService service = new AppointmentService(appointmentStubRepository.Object);
            bool b = service.CheckIfExistsByTime(timeofAppointment);

            b.ShouldBe(expectedValue);
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new DateTime(2021, 12, 15, 8, 0, 0), true });
            retVal.Add(new object[] { new DateTime(2021, 12, 15, 11, 0, 0), false });
            return retVal;

        }

        public static List<Appointment> CreateAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            Appointment ap1 = new Appointment
            {
                Id = 1,
                StartTime = new DateTime(2021, 12, 15, 8, 0, 0),
                DurationInMunutes = 30,
                ApointmentDescription = "",
                IsDeleted = false,
                DoctorId = 1,
                PatientId = 1
            };

            Appointment ap2 = new Appointment
            {
                Id = 2,
                StartTime = new DateTime(2021, 12, 15, 8, 30, 0),
                DurationInMunutes = 30,
                ApointmentDescription = "",
                IsDeleted = false,
                DoctorId = 1,
                PatientId = 1
            };

            Appointment ap3 = new Appointment
            {
                Id = 3,
                StartTime = new DateTime(2021, 12, 15, 9, 0, 0),
                DurationInMunutes = 30,
                ApointmentDescription = "",
                IsDeleted = false,
                DoctorId = 1,
                PatientId = 1
            };
            
            appointments.Add(ap1);
            appointments.Add(ap2);
            appointments.Add(ap3);

            return appointments;
        }
    }
}
