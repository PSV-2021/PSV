using Hospital.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class WorkingHoursSqlRepository : IWorkingHoursRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkingHours> GetAll()
        {
            throw new NotImplementedException();
        }

        public WorkingHours GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(WorkingHours newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(WorkingHours editedObject)
        {
            throw new NotImplementedException();
        }

        public WorkingHours GetByDoctorAndDate(int id, DateTime date)
        {
            return GetAll().Where(day => day.Id.Equals(id) && DateTime.Compare(day.BeginningDate, date) == 0).FirstOrDefault();
        }
    }
}
