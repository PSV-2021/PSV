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
        private DoctorSqlRepository DoctorSqlRepository { get; set; }

        public DoctorService()
        {
        
        }

        public DoctorService(DoctorSqlRepository doctorSqlRepository)
        {
            DoctorSqlRepository = doctorSqlRepository;
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

    }
}