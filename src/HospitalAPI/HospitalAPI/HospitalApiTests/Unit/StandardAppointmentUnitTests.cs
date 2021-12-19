using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Hospital.Schedule.Repository;
using Moq;
using Hospital.Schedule.Model;
using Hospital.Schedule.Service;
using Shouldly;
using HospitalAPI.DTO;
using HospitalAPI.Verification;

namespace HospitalApiTests.Unit
{
    public class StandardAppointmentUnitTests
    {
        private AppointmentVerification appointmentVerification = new AppointmentVerification();

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
            Appointment appointment1 = new Appointment(1, new DateTime(2021, 12, 15, 8, 0, 0), 30, "", false, 1, 1, false);
            Appointment appointment2 = new Appointment(2, new DateTime(2021, 12, 12, 8, 30, 0), 30, "", false, 1, 2, false);
            Appointment appointment3 = new Appointment(3, new DateTime(2021, 12, 12, 9, 0, 0), 30, "", false, 1, 1, false);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);

            return appointments;
        }

        [Fact]
        public void Check_appointment_start_null()
        {
            AppointmentDTO appointment = GenerateAppointment();
            appointment.StartTime = null;
            Assert.False(appointmentVerification.Verify(appointment));
        }

        [Fact]
        public void Check_appointment_doctorId_null()
        {
            AppointmentDTO appointment = GenerateAppointment();
            appointment.DoctorId = null;
            Assert.False(appointmentVerification.Verify(appointment));
        }

        [Fact]
        public void Check_appointment_patientId_null()
        {
            AppointmentDTO appointment = GenerateAppointment();
            appointment.PatientId = null;
            Assert.False(appointmentVerification.Verify(appointment));
        }

        private AppointmentDTO GenerateAppointment()
        {
            return new AppointmentDTO { StartTime = "20/01/2000 00:00:00", DoctorId = "1", PatientId = "1" };
        }
    }
}
