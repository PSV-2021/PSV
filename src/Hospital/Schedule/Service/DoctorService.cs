using System;
using System.Collections.Generic;
using Factory;
using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;

namespace Hospital.Schedule.Service
{
    public class DoctorService
    {
        private IDoctorRepository DoctorRepository { get; }

        private DoctorSqlRepository DoctorSqlRepository { get; set; }

        private IRepositoryFactory RepositoryFactory { get; }

        public DoctorService()
        {
          //  RepositoryFactory = (ApplicationDataSource.GetInstance()).GetRepositoryFactory();
           // DoctorRepository = RepositoryFactory.CreateDoctorRepository();
        }

        public DoctorService(IDoctorRepository doctorRepository)
        {
            DoctorRepository = doctorRepository;
        }

        public DoctorService(DoctorSqlRepository doctorSqlRepository)
        {
            DoctorSqlRepository = doctorSqlRepository;
        }

        public Doctor GetDoctorByJmbg(string jmbg)
        {
            return DoctorRepository.GetOne(jmbg);
        }
      
        public List<Doctor> GetGeneralDoctors()
        {
            return DoctorSqlRepository.GetAvalibleGeneralDoctors();
        }
        public string GetDoctorById(int id)
        {
            return DoctorSqlRepository.GetMameAndSurnameById(id);

        }

        public List<Doctor> GetAllDoctors()
        {
            return DoctorSqlRepository.GetAll();
        }
        public List<Doctor> GetDoctorsBySpeciality(int specialityId)
        {
            return DoctorSqlRepository.GetDoctorsBySpeciality(specialityId);
        }

        public List<Doctor> GetDoctorsWithSpeciality(Speciality speciality)
        {
            return DoctorRepository.GetDoctorsWithSpeciality(speciality);
        }

      
   

        private void printUnavailableWorkingHoursRemovalMessage(List<Appointment> appointments)
        {
            String text = "Ne možete da uklonite radno vreme. Lekar ima zakazano " + appointments.Count + " termina za dati period:";
            foreach(Appointment a in appointments)
            {
                text += "\n\t";
                text += a.StartTime.ToString("dd.MM.yyyy. HH:mm");
            }
            text += "\nKada otkažete ili odložite ove termine moći ćete da uklonite radno vreme.";
           
        }

        private List<Appointment> GetDoctorAppointmentsInWorkingHoursPeriod(string jmbg, WorkingHours workingHours)
        {
            AppointmentService aps = new AppointmentService();
            List<Appointment> scheduledAppointments = aps.GetAllAppointments();
            List<Appointment> appointments = new List<Appointment>();
            foreach(Appointment a in scheduledAppointments)
            {
                if (a.Doctor.Jmbg.Equals(jmbg) && (a.StartTime.Date>=workingHours.BeginningDate.Date && a.EndTime.Date <= workingHours.EndDate))
                {
                    appointments.Add(a);
                }
            }
            return appointments;

        }

        
      
        public Doctor LoadDoctor()
        {
            return DoctorRepository.GetOne("1708962324890");
        }
    }
}