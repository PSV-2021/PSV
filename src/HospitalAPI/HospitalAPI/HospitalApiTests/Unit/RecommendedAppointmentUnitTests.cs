using Hospital.DTO;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.Schedule.Service;
using Hospital.SharedModel;
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
    public class RecommendedAppointmentUnitTests
    {

        [Fact]
        public void Recommended_by_doctor_priority_success()
        {
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorRepository = CreateDoctorStubRepository();
            var searchAppointments = CreateSearchAppointmentsDTOSuccess();

            AppointmentService appointmentService = new AppointmentService(appointmentRepository, doctorRepository);

            List<Appointment> recommendedAppointments = appointmentService.RecommendDoctor(searchAppointments);

            recommendedAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Recommended_by_doctor_priority_fail()
        {
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorRepository = CreateDoctorStubRepository();
            var searchAppointments = CreateSearchAppointmentsDTOFail();

            AppointmentService appointmentService = new AppointmentService(appointmentRepository, doctorRepository);

            List<Appointment> recommendedAppointments = appointmentService.RecommendDoctor(searchAppointments);

            recommendedAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_available()
        {
            var appointmentRepository = CreateAppointmentStubRepository();

            AppointmentService appointmentService = new AppointmentService(appointmentRepository, null);

            var workDay = appointmentService.GetAvailable(1, new DateTime(2021, 12, 12));
            workDay.Count.ShouldBe(13);
        }

        public static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();

            stubRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.StartTime.Date.CompareTo(date.Date) == 0).ToList());


            return stubRepository.Object;
        }

        public static List<Appointment> CreateListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            Appointment appointment1 = new Appointment(1, new DateTime(2021, 12, 12, 8, 0, 0), 30, "", false, 1, 1, false);
            Appointment appointment2 = new Appointment(2, new DateTime(2021, 12, 12, 8, 30, 0), 30, "", false, 1, 2, false);
            Appointment appointment3 = new Appointment(3, new DateTime(2021, 12, 12, 9, 0, 0), 30, "", false, 1, 3, false);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);

            return appointments;
        }

        public static IDoctorRepository CreateDoctorStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctors = CreateDoctors();

            stubRepository.Setup(x => x.GetAll()).Returns(doctors);

            return stubRepository.Object;
        }

        public static List<Doctor> CreateDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            Doctor doctor1 = new Doctor("Milan", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 1, 1, 0, Sex.male);

            Doctor doctor2 = new Doctor("Rade", "Radic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                "miki56", "02145", UserType.doctor, 200000, 2, 2, 0, Sex.male);
         
            doctors.Add(doctor1);
            doctors.Add(doctor2);

            return doctors;
        }

        public SearchAppointmentsDTO CreateSearchAppointmentsDTOSuccess()
        {
            return new SearchAppointmentsDTO
            {               
                StartInterval = "12/12/2021",
                EndInterval = "12/16/2021",
                DoctorId = 1,
                Priority = 1,
                SpecializationId = 1
            };

        }

        public SearchAppointmentsDTO CreateSearchAppointmentsDTOFail()
        {
            return new SearchAppointmentsDTO
            {
                StartInterval = "12/17/2021",
                EndInterval = "12/19/2021",
                DoctorId = 1,
                Priority = 1,
                SpecializationId = 1
            };

        }

    }
}
