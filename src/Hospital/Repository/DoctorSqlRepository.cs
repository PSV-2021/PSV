﻿using Hospital.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Repository
{
    public class DoctorSqlRepository : IDoctorRepository
    { 
        public MyDbContext dbContext { get; set; }

        public DoctorSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DoctorSqlRepository()
        {
        }

        public List<Doctor> GetDoctorsWithSpeciality(Speciality speciality)
        {
            throw new System.NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            return dbContext.Doctors.ToList();
        }

        public Doctor GetOne(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Save(Doctor newObject)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Doctor editedObject)
        {
            throw new System.NotImplementedException();
        }

        public List<Doctor> GetAvalibleGeneralDoctors()
        {
            var d = dbContext.Doctors.OrderBy(p => p.NumberOfPatients).FirstOrDefault();
            List<Doctor> retVal = (List<Doctor>)dbContext.Doctors.ToList().Where(s => s.SpecialityId == 1).Where(s=>s.NumberOfPatients <= d.NumberOfPatients + 2).ToList();

            return retVal;
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}