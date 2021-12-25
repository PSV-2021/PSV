using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Castle.Core.Internal;
using Hospital.DTO;
using Hospital.MedicalRecords.Model;
using Hospital.RoomsAndEquipment.Model;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;

namespace Hospital.Schedule.Service
{
    public class AppointmentService
    {
        private const int appointmentDurationInMunutes = 30;
        private IAppointmentRepository AppointmentRepository { get; }
        private AppointmentSqlRepository AppointmentSqlRepository { get; set; }
        private Appointment ChangingAppointment { get; set; }
        private EventsLogService EventsLogService { get; set; }
        private RecommendedAppointmentSqlRepository RecommendedAppointmentSqlRepository { get; set; }
        private IDoctorRepository DoctorRepository { get; }
        private Appointment appointment = new Appointment();


        int numberOfAppointmentsInDay = 16;
        double lengthOfAppointmentInMinutes = 30;
        public AppointmentService()
        {
            AppointmentRepository = new AppointmentFileRepository();
            EventsLogService = new EventsLogService();
            ChangingAppointment = new Appointment();
        }

        public bool CheckIfExistsByTime(DateTime timeofAppointment)
        {
            List<Appointment> appointments = AppointmentRepository.GetAll().ToList();
            foreach (Appointment a in appointments)
            {
                if (DateTime.Compare(a.StartTime, timeofAppointment) == 0)
                    return true;
            }
            return false;
        }

        public AppointmentService(IAppointmentRepository IsurveyRepository)
        {
            AppointmentRepository = IsurveyRepository;
        }

        public AppointmentService(AppointmentSqlRepository appointmentSqlRepository)
        {
            AppointmentRepository = appointmentSqlRepository;
            AppointmentSqlRepository = appointmentSqlRepository;
        }

        public AppointmentService(RecommendedAppointmentSqlRepository recommendedAppointmentSqlRepository,
            DoctorSqlRepository doctorSqlRepository)
        {
            AppointmentRepository = recommendedAppointmentSqlRepository;
            DoctorRepository = doctorSqlRepository;
        }

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            AppointmentRepository = appointmentRepository;
            DoctorRepository = doctorRepository;
        }

        public List<Appointment> GetAppointmentsByDoctorAndDate(int idDoctor, DateTime chosenDate)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<Appointment> occupiedAppointments = new List<Appointment>();
            occupiedAppointments.AddRange(AppointmentSqlRepository.GetOccupiedAppointmentsByDoctorAndDate(idDoctor, chosenDate));

            if (occupiedAppointments.Count == 0)
            {
                appointments = CreateAllFreeAppointmentsByDate(chosenDate);
            }
            else
            { 
                foreach (Appointment occupiedAppointment in occupiedAppointments){
                    appointments = RemoveAppointmentFromAppointmentList(occupiedAppointment, chosenDate);
                }
            }
            return appointments;
        }

        public void SaveAppointmentSql(Appointment appointment, MyDbContext dbContext)
        {
            AppointmentSqlRepository.Save(appointment);
        }

        private List<Appointment> RemoveAppointmentFromAppointmentList(Appointment occupiedAppointment, DateTime chosenDate)
        {

            List<Appointment> appointments = CreateAllFreeAppointmentsByDate(chosenDate);
            foreach (Appointment appointment in appointments.ToList())
            {
                if(DateTime.Compare(occupiedAppointment.StartTime,appointment.StartTime) == 0)
                {
                    appointments.Remove(appointment);
                }
            }
            return appointments;
        }

        private List<Appointment> CreateAllFreeAppointmentsByDate(DateTime chosenDate)
        {
            List<Appointment> allPossibleAppointmentsForDate = new List<Appointment>();
            Appointment appointment = new Appointment { StartTime = chosenDate.AddHours(8) }; //hospital begins to work at 8 am
            for (int i = 0; i < numberOfAppointmentsInDay ; i++)
            {
                Appointment newAppointmentLocal = new Appointment { StartTime = appointment.StartTime };
                allPossibleAppointmentsForDate.Add(newAppointmentLocal);
                appointment.StartTime = appointment.StartTime.AddMinutes(lengthOfAppointmentInMinutes);
            }
            return allPossibleAppointmentsForDate;
        }

        public List<Appointment> GetAllAppointments()
        {
            return AppointmentRepository.GetAll();
        }

        public Boolean SaveAppointment(Appointment newAppointment)
        {
            return AppointmentRepository.Save(newAppointment);
        }

        //RecommendedAppointments

        public List<Appointment> GetAvailableAppointment(SearchAppointmentsDTO searchAppointments)
        {
            List<Appointment> appointments = AvailableDoctorAndDateRange(searchAppointments);

            if (appointments.IsNullOrEmpty())
            {
                appointments = UseStrategy(searchAppointments);
            }

            return appointments;
        }

        private List<Appointment> UseStrategy(SearchAppointmentsDTO searchAppointments)
        {
            List<Appointment> appointments = new List<Appointment>();

            if (searchAppointments.Priority == 1) //strategija za prioritet doktora
            {
                appointments = RecommendDoctor(searchAppointments);
            }
            else
            {
                //strategija za prioritet datuma
                appointments = RecommendDatePriority(searchAppointments);

            }

            return appointments;

        }

        public List<Appointment> AvailableDoctorAndDateRange(SearchAppointmentsDTO searchAppointments)
        {
            DateTime start = DateTime.Parse(searchAppointments.StartInterval);
            DateTime end = DateTime.Parse(searchAppointments.EndInterval);

            List<Appointment> availableAppointments = new List<Appointment>();

            for (DateTime date = start; date.Date <= end.Date; date = date.AddDays(1))
            {
                availableAppointments.AddRange(GetAvailable(searchAppointments.DoctorId, date));
            }

            return availableAppointments;
        }

        public List<Appointment> GetAvailable(int doctorId, DateTime date)
        {
            List<Appointment> occupied = DoctorAndDate(doctorId, date);
            List<Appointment> allAppointments = GetAppointments(doctorId, date);
            List<Appointment> availableAppointments = new List<Appointment>(allAppointments);

            foreach (Appointment appointmentIt in allAppointments)
            {
                Appointment appointment = occupied.FirstOrDefault(a => a.IsOccupied(appointmentIt.StartTime) && !a.isCancelled);

                if (appointment != null)
                    availableAppointments.Remove(appointmentIt);
            }

            return availableAppointments;
        }

        public List<Appointment> GetAppointments(int doctorId, DateTime date)
        {
            List<Appointment> appointments = new List<Appointment>();
            int appointmentsInDay = 16;
            DateTime appointmentStart = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            Appointment appointment = new Appointment { StartTime = appointmentStart.AddHours(8) };

            for (int i = 0; i < appointmentsInDay; i++)
            {
                Appointment newAppointmentLocal = new Appointment(appointment.StartTime,doctorId);
                appointments.Add(newAppointmentLocal);
                appointment.StartTime = appointment.StartTime.AddMinutes(appointmentDurationInMunutes);
            }

            return appointments;

        }

        public List<Appointment> DoctorAndDate(int doctorId, DateTime date)
        {
            return AppointmentRepository.Get(doctorId, date).ToList();
        }

        public List<Appointment> RecommendDoctor(SearchAppointmentsDTO searchAppointments)
        {
            List<Appointment> appointmentsBeforeDate = AppointmentsBeforeDate(searchAppointments);
            List<Appointment> appointentsAfterDate = AppointmentsAfterDate(searchAppointments);
            List<Appointment> recommendedAppointments = new List<Appointment>();

            recommendedAppointments.AddRange(appointmentsBeforeDate);
            recommendedAppointments.AddRange(appointentsAfterDate);

            return recommendedAppointments;
        }

        public List<Appointment> AppointmentsBeforeDate(SearchAppointmentsDTO searchAppointments)
        {
            DateTime startDate = DateTime.Parse(searchAppointments.StartInterval).Date.AddDays(-1);
            DateTime minDate = DateTime.Parse(searchAppointments.EndInterval).Date.AddDays(-5);

            if (minDate < DateTime.Now.Date)
                minDate = DateTime.Now.Date;

            List<Appointment> allAvailableAppointments = new List<Appointment>();

            while (appointment.CheckBeforeDate(startDate, minDate))
            {
                List<Appointment> availableAppointments = GetAvailable(searchAppointments.DoctorId, startDate);
                allAvailableAppointments.AddRange(availableAppointments);
                startDate = startDate.AddDays(-1);
            }
            return allAvailableAppointments;
        }

        public List<Appointment> AppointmentsAfterDate(SearchAppointmentsDTO searchAppointments)
        {
            DateTime endDate = DateTime.Parse(searchAppointments.StartInterval).Date.AddDays(1);
            DateTime maxDate = DateTime.Parse(searchAppointments.EndInterval).Date.AddDays(5);

            List<Appointment> allAvailableAppointments = new List<Appointment>();

            while (appointment.CheckAfterDate(endDate, maxDate))
            {
                List<Appointment> availaAppointments = GetAvailable(searchAppointments.DoctorId, endDate);
                allAvailableAppointments.AddRange(availaAppointments);
                endDate = endDate.AddDays(1);
            }

            return allAvailableAppointments;
        }

        public static List<AvailableAppointmentsDTO> AvailableAppointmentsDTODoctor(List<Appointment> appointments)
        {
            List<AvailableAppointmentsDTO> availableAppointmentsDTO = new List<AvailableAppointmentsDTO>();

            foreach (Appointment appointment in appointments)
            {
                AvailableAppointmentsDTO dto = new AvailableAppointmentsDTO
                {
                    Start = appointment.StartTime,
                    DoctorId = appointment.DoctorId
                };
                availableAppointmentsDTO.Add(dto);
            }
            return availableAppointmentsDTO;
        }

        //zakazivanje

        public void Schedule(Appointment appointment)
        {
            AppointmentRepository.Create(appointment);
        }

        public static Appointment ScheduleAppointmentDTOToAppointment(DateTime start, int doctorId)
        {
            return new Appointment(start, 30, "", false, doctorId, 2, false);
        }

        public List<Appointment> RecommendDatePriority(SearchAppointmentsDTO searchAppointments)
        {
            List<Doctor> doctors = DoctorRepository.GetDoctorsBySpeciality(searchAppointments.SpecializationId);
            DateTime start = DateTime.Parse(searchAppointments.StartInterval);
            DateTime end = DateTime.Parse(searchAppointments.EndInterval);
            List<Appointment> availableAppointments = new List<Appointment>();
            foreach (Doctor d in doctors)
            {
                if (d.Id != searchAppointments.DoctorId)
                    availableAppointments = AppointmentsForDoctorInDateRange(start, end, d.Id);
            }
            return availableAppointments;
        }

        private List<Appointment> AppointmentsForDoctorInDateRange(DateTime start, DateTime end, int doctorId)
        {
            List<Appointment> availableAppointments = new List<Appointment>();
            for (DateTime date = start; date.Date <= end.Date; date = date.AddDays(1))
                availableAppointments.AddRange(GetAvailable(doctorId, date));
            return availableAppointments;
        }

    }
}

