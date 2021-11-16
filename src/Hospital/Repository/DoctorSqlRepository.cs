using Hospital.Model;
using Model;
using Repository;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
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

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}