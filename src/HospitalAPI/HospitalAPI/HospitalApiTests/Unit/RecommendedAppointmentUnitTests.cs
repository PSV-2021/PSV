using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalApiTests.Unit
{
    public class RecommendedAppointmentUnitTests
    {
        [Fact]
        public void Recommended_by_doctor_priority_success()
        {
            var appointmentStubRepository = new Mock<IAppointmentRepository>();
            var doctorStubRepository = new Mock<IDoctorRepository>();

            var appointmentService = new AppointmentService(appointmentStubRepository.Object);

            List<Appointment> recommendedAppointments = GenerateStubData();

            //List<Appointment> recommendedAppointments = appointmentService.GetAvailableByStrategy(priority);

            //recommendedAppointments.ShouldNotBeEmpty();


            appointmentStubRepository.Setup(s => s.GetAll()).Returns(recommendedAppointments);

            AppointmentService service = new AppointmentService(appointmentStubRepository.Object);
            //bool b = service.CheckIfExistsById(id);

            //b.ShouldBe(expectedValue);

        }

        private static List<Appointment> GenerateStubData()
        {
            List<Appointment> appointments = new List<Appointment>();
            /*
            Appointment appointment1 = new Appointment(1, DateTime.Now, 1);
            Appointment appointment2 = new Appointment(1, DateTime.Now, 2);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            */

            return appointments;
        }
    }
}
