using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.MedicalRecords.Repository
{
    class PrescriptionSqlRepository : IPrescriptionRepository
    {
        public MyDbContext DbContext { get; set; }

        public PrescriptionSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Prescription> GetAll()
        {
            throw new NotImplementedException();
        }

        public Prescription GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Prescription newObject)
        {
            try
            {
                DbContext.Prescriptions.Add(newObject);
                DbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return false;
        }

        public bool Update(Prescription editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
