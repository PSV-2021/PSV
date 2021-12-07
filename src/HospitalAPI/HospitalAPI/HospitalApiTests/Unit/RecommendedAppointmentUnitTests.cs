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
    public class RecommendedAppointmentUnitTests
    {
        [Fact]
        public void Recommended_by_doctor_priority_success()
        {
            var doctorWorkingHoursRepository = CreateDoctorWorkingHoursStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();
            //var doctorService = CreateDoctorService();
            var doctorRepository = CreateDoctorStubRepository();
            var searchAppointments = CreateSearchAppointmentsDTOSuccess();

            AppointmentService appointmentService = new AppointmentService(doctorWorkingHoursRepository, appointmentRepository, doctorRepository);

            List<Appointment> recommendedAppointments = appointmentService.GetAvailableAppointment(searchAppointments);

            recommendedAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Recommended_by_doctor_priority_fail()
        {
            var doctorWorkingHoursRepository = CreateDoctorWorkingHoursStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();
            var doctorRepository = CreateDoctorStubRepository();
            var searchAppointments = CreateSearchAppointmentsDTOFail();

            AppointmentService appointmentService = new AppointmentService(doctorWorkingHoursRepository, appointmentRepository, doctorRepository);

            List<Appointment> recommendedAppointments = appointmentService.GetAvailableAppointment(searchAppointments);

            recommendedAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Get_available()
        {
            var doctorWorkingHoursRepository = CreateDoctorWorkingHoursStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();

            AppointmentService appointmentService = new AppointmentService(doctorWorkingHoursRepository, appointmentRepository, null);

            var workDay = appointmentService.GetAvailable(1, new DateTime(2021, 12, 12));
            workDay.Count.ShouldBe(3);
        }

        /*
        [Fact]
        public void Schedule_appointment()
        {
            var doctorWorkingHoursRepository = CreateDoctorWorkingHoursStubRepository();
            var appointmentRepository = CreateAppointmentStubRepository();

            AppointmentService appointmentService = new AppointmentService(doctorWorkingHoursRepository, appointmentRepository, null);

            //var createdAppointment = appointmentService.ScheduleAppointment(appointment);
            //createdAppointment.ShouldNotBe(null);

        }*/

        public static IWorkingHoursRepository CreateDoctorWorkingHoursStubRepository()
        {
            var stubRepository = new Mock<IWorkingHoursRepository>();
            var workDays = CreateDoctorWorkingHours();
            stubRepository.Setup(x => x.GetByDoctorAndDate(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    workDays.FirstOrDefault(wd => wd.Id.Equals(id) && wd.BeginningDate.Day.CompareTo(date) == 0));

            return stubRepository.Object;
        }

        public static List<WorkingHours> CreateDoctorWorkingHours()
        {
            List<WorkingHours> doctorWorkingHours = new List<WorkingHours>();

            WorkingHours day1 = new WorkingHours{ Id = 1, BeginningDate = new DateTime(2021, 12, 12), EndDate = new DateTime(2021, 12, 16)};

            doctorWorkingHours.Add(day1);

            return doctorWorkingHours;
        }

        public static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();
            var appointments = CreateListOfAppointments();

            //stubRepository.Setup(x => x.Create(It.IsAny<Appointment>())).Returns(appointment);
            stubRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<DateTime>())).Returns(
                (int id, DateTime date) =>
                    appointments.Where(a => a.DoctorId.Equals(id) && a.StartTime.Date.CompareTo(date.Date) == 0).ToList());


            return stubRepository.Object;
        }

        public static List<Appointment> CreateListOfAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            Appointment appointment1 = new Appointment
            {
                Id = 1,
                StartTime = new DateTime(2021, 12, 12, 7, 0, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 1,
                Canceled = false
            };

            Appointment appointment2 = new Appointment
            {
                Id = 2,
                StartTime = new DateTime(2021, 12, 12, 7, 30, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 2,
                Canceled = false
            };

            Appointment appointment3 = new Appointment
            {
                Id = 3,
                StartTime = new DateTime(2021, 12, 12, 8, 0, 0),
                DurationInMunutes = 30,
                DoctorId = 1,
                PatientId = 3,
                Canceled = false
            };
            
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

            Doctor doctor1 = new Doctor
            {
                Name = "Milan",
                Surname = "Popovic",
                Jmbg = "3009998805137",
                DateOfBirth = new DateTime(1998, 04, 20),
                Sex = Sex.male,
                PhoneNumber = "0641664608",
                Adress = "Bulevar Oslobodjenja 4",
                Email = "milan@gmail.com",
                Username = "miki56",
                Password = "02145",
                Type = UserType.doctor,
                SalaryInRsd = 200000,
                WorkingSchedule = new List<WorkingHours>(),
                VacationDays = new List<VacationDays>(),
                AvailableDaysOff = 20,
                Id = 1,
                SpecialityId = 1,
                NumberOfPatients = 0,
                WorkingHoursId = 1
            };

            Doctor doctor2 = new Doctor
            {
                Name = "Rade",
                Surname = "Radic",
                Jmbg = "3009998805137",
                DateOfBirth = new DateTime(1998, 04, 20),
                Sex = Sex.male,
                PhoneNumber = "0641664608",
                Adress = "Bulevar Oslobodjenja 4",
                Email = "milan@gmail.com",
                Username = "miki56",
                Password = "02145",
                Type = UserType.doctor,
                SalaryInRsd = 200000,
                WorkingSchedule = new List<WorkingHours>(),
                VacationDays = new List<VacationDays>(),
                AvailableDaysOff = 20,
                Id = 1,
                SpecialityId = 2,
                NumberOfPatients = 0,
                WorkingHoursId = 1

            };
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

        public IDoctorService CreateDoctorService()
        {
            var doctorStubRepository = CreateDoctorStubRepository();

            DoctorService doctorService = new DoctorService(doctorStubRepository);

            return doctorService;
        }

    }
}
