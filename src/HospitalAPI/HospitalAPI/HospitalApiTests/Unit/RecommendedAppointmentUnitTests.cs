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

            Doctor doctor3 = new Doctor("Milana", "Popovic", "3009998805137", new DateTime(1998, 04, 20), "0641664608", "Bulevar Oslobodjenja 4", "milan@gmail.com",
                   "miki56", "02145", UserType.doctor, 200000, 3, 1, 0, Sex.female);

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


        public static IDoctorRepository CreateDoctorDateStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            var doctors = CreateDoctors();
            int specialityId = 1;
            stubRepository.Setup(x => x.GetAll()).Returns(doctors);
            stubRepository.Setup(x => x.GetDoctorsBySpeciality(specialityId)).Returns(doctors);

            return stubRepository.Object;
        }
        public SearchAppointmentsDTO CreateSearchAppointmentsSuccess()
        {
            return new SearchAppointmentsDTO
            {
                StartInterval = "12/12/2021",
                EndInterval = "12/19/2021",
                DoctorId = 2,
                Priority = 2,
                SpecializationId = 1
            };

        }

        public SearchAppointmentsDTO CreateSearchAppointmentsFail()
        {
            return new SearchAppointmentsDTO
            {
                StartInterval = "12/12/2021",
                EndInterval = "12/12/2021",
                DoctorId = 2,
                Priority = 2,
                SpecializationId = 2
            };

        }
        [Fact]
        public void Recommended_by_date_priority_success()
        {
            var appointmentRepository = CreateAppointmentDateStubRepository();
            var doctorRepository = CreateDoctorDateStubRepository();
            var searchAppointments = CreateSearchAppointmentsSuccess();

            AppointmentService appointmentService = new AppointmentService(appointmentRepository, doctorRepository);
            List<Appointment> recommendedAppointments = appointmentService.RecommendDatePriority(searchAppointments);

            recommendedAppointments.ShouldNotBeEmpty();
            recommendedAppointments.First().DoctorId.ShouldBe(1);
            recommendedAppointments.First().StartTime.ShouldBe(new DateTime(2021 , 12 , 12, 9, 30, 0));

        }

        public static IAppointmentRepository CreateAppointmentDateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();

            stubRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.StartTime.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }


        [Fact]
        public void Recommended_by_date_priority_other_doctor()
        {
            var appointmentRepository = CreateAppointmentDateFullStubRepository();
            var doctorRepository = CreateDoctorDateStubRepository();
            var searchAppointments = CreateSearchAppointmentsFull();

            AppointmentService appointmentService = new AppointmentService(appointmentRepository, doctorRepository);
            List<Appointment> recommendedAppointments = appointmentService.RecommendDatePriority(searchAppointments);

            recommendedAppointments.ShouldNotBeEmpty();
            recommendedAppointments.First().DoctorId.ShouldBe(2);
            recommendedAppointments.First().StartTime.ShouldBe(new DateTime(2021, 12, 12, 8, 00, 0));

        }

        public static List<Appointment> CreateFullListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            Appointment appointment1 = new Appointment(1, new DateTime(2021, 12, 12, 8, 0, 0), 30, "", false, 1, 1, false);
            Appointment appointment2 = new Appointment(2, new DateTime(2021, 12, 12, 8, 30, 0), 30, "", false, 1, 2, false);
            Appointment appointment3 = new Appointment(3, new DateTime(2021, 12, 12, 9, 0, 0), 30, "", false, 1, 3, false);
            Appointment appointment4 = new Appointment(1, new DateTime(2021, 12, 12, 9, 30, 0), 30, "", false, 1, 1, false);
            Appointment appointment5 = new Appointment(2, new DateTime(2021, 12, 12, 10, 0, 0), 30, "", false, 1, 2, false);
            Appointment appointment6 = new Appointment(3, new DateTime(2021, 12, 12, 10, 30, 0), 30, "", false, 1, 3, false);
            Appointment appointment7 = new Appointment(1, new DateTime(2021, 12, 12, 11, 0, 0), 30, "", false, 1, 1, false);
            Appointment appointment8 = new Appointment(2, new DateTime(2021, 12, 12, 11, 30, 0), 30, "", false, 1, 2, false);
            Appointment appointment9 = new Appointment(3, new DateTime(2021, 12, 12, 12, 0, 0), 30, "", false, 1, 3, false);
            Appointment appointment10 = new Appointment(1, new DateTime(2021, 12, 12, 12, 30, 0), 30, "", false, 1, 1, false);
            Appointment appointment11 = new Appointment(2, new DateTime(2021, 12, 12, 13, 0, 0), 30, "", false, 1, 2, false);
            Appointment appointment12 = new Appointment(3, new DateTime(2021, 12, 12, 13, 30, 0), 30, "", false, 1, 3, false);
            Appointment appointment13 = new Appointment(2, new DateTime(2021, 12, 12, 14, 0, 0), 30, "", false, 1, 2, false);
            Appointment appointment14 = new Appointment(3, new DateTime(2021, 12, 12, 14, 30, 0), 30, "", false, 1, 3, false);
            Appointment appointment15 = new Appointment(1, new DateTime(2021, 12, 12, 15, 0, 0), 30, "", false, 1, 1, false);
            Appointment appointment16 = new Appointment(2, new DateTime(2021, 12, 12, 15, 30, 0), 30, "", false, 1, 2, false);
           
            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);
            appointments.Add(appointment4);
            appointments.Add(appointment5);
            appointments.Add(appointment6);
            appointments.Add(appointment7);
            appointments.Add(appointment8);
            appointments.Add(appointment9);
            appointments.Add(appointment10);
            appointments.Add(appointment11);
            appointments.Add(appointment12);
            appointments.Add(appointment13);
            appointments.Add(appointment14);
            appointments.Add(appointment15);
            appointments.Add(appointment16);

            return appointments;
        }
        public static List<Appointment> CreateFailListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            Appointment appointment1 = new Appointment(1, new DateTime(2021, 12, 12, 8, 0, 0), 30, "", false, 2, 1, false);
            Appointment appointment2 = new Appointment(2, new DateTime(2021, 12, 12, 8, 30, 0), 30, "", false, 2, 2, false);
            Appointment appointment3 = new Appointment(3, new DateTime(2021, 12, 12, 9, 0, 0), 30, "", false, 2, 3, false);
            Appointment appointment4 = new Appointment(1, new DateTime(2021, 12, 12, 9, 30, 0), 30, "", false, 2, 1, false);
            Appointment appointment5 = new Appointment(2, new DateTime(2021, 12, 12, 10, 0, 0), 30, "", false, 2, 2, false);
            Appointment appointment6 = new Appointment(3, new DateTime(2021, 12, 12, 10, 30, 0), 30, "", false, 2, 3, false);
            Appointment appointment7 = new Appointment(1, new DateTime(2021, 12, 12, 11, 0, 0), 30, "", false, 2, 1, false);
            Appointment appointment8 = new Appointment(2, new DateTime(2021, 12, 12, 11, 30, 0), 30, "", false, 2, 2, false);
            Appointment appointment9 = new Appointment(3, new DateTime(2021, 12, 12, 12, 0, 0), 30, "", false, 2, 3, false);
            Appointment appointment10 = new Appointment(1, new DateTime(2021, 12, 12, 12, 30, 0), 30, "", false, 2, 1, false);
            Appointment appointment11 = new Appointment(2, new DateTime(2021, 12, 12, 13, 0, 0), 30, "", false, 2, 2, false);
            Appointment appointment12 = new Appointment(3, new DateTime(2021, 12, 12, 13, 30, 0), 30, "", false, 2, 3, false);
            Appointment appointment13 = new Appointment(2, new DateTime(2021, 12, 12, 14, 0, 0), 30, "", false, 2, 2, false);
            Appointment appointment14 = new Appointment(3, new DateTime(2021, 12, 12, 14, 30, 0), 30, "", false, 2, 3, false);
            Appointment appointment15 = new Appointment(1, new DateTime(2021, 12, 12, 15, 0, 0), 30, "", false, 2, 1, false);
            Appointment appointment16 = new Appointment(2, new DateTime(2021, 12, 12, 15, 30, 0), 30, "", false, 2, 2, false);

            appointments.Add(appointment1);
            appointments.Add(appointment2);
            appointments.Add(appointment3);
            appointments.Add(appointment4);
            appointments.Add(appointment5);
            appointments.Add(appointment6);
            appointments.Add(appointment7);
            appointments.Add(appointment8);
            appointments.Add(appointment9);
            appointments.Add(appointment10);
            appointments.Add(appointment11);
            appointments.Add(appointment12);
            appointments.Add(appointment13);
            appointments.Add(appointment14);
            appointments.Add(appointment15);
            appointments.Add(appointment16);

            return appointments;
        }

        public SearchAppointmentsDTO CreateSearchAppointmentsFull()
        {
            return new SearchAppointmentsDTO
            {
                StartInterval = "12/12/2021",
                EndInterval = "12/12/2021",
                DoctorId = 1,
                Priority = 2,
                SpecializationId = 1
            };

        }
        public static IAppointmentRepository CreateAppointmentDateFullStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateFullListOfAppointments();
            stubRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.StartTime.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }
        public static IAppointmentRepository CreateAppointmentDateFailStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateFailListOfAppointments();
            stubRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.StartTime.Date.CompareTo(date.Date) == 0).ToList());

            return stubRepository.Object;
        }

        [Fact]
        public void Recommended_by_date_priority_fail()
        {
            var appointmentRepository = CreateAppointmentDateFailStubRepository();
            var doctorRepository = CreateDoctorDateStubRepository();
            var searchAppointments = CreateSearchAppointmentsFail();

            AppointmentService appointmentService = new AppointmentService(appointmentRepository, doctorRepository);
            List<Appointment> recommendedAppointments = appointmentService.RecommendDatePriority(searchAppointments);

            recommendedAppointments.ShouldBeEmpty();

        }

    }
}
