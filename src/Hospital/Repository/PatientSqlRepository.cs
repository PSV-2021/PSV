﻿using Hospital.Model;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository
{
    public class PatientSqlRepository : IPatientRepository
    {
        public MyDbContext dbContext { get; set; }

        public  PatientSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Patient newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Patient editedObject)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
