using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Repository
{
    public class MedicalRecordSqlRepository : IMedicalRecordRepository
    {
        public MyDbContext dbContext { get; set; }

        public MedicalRecordSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MedicalRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(MedicalRecord newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(MedicalRecord editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
