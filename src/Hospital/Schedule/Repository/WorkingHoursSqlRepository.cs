using Hospital.Schedule.Model;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class WorkingHoursSqlRepository : IWorkingHoursRepository
    {
        private MyDbContext context;

        public WorkingHoursSqlRepository(MyDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkingHours> GetAll()
        {
            return context.WorkingHours.ToList();
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
            return GetAll().Where(day => day.Id.Equals(id) && DateTime.Compare(day.BeginningDate, date) == -1 && DateTime.Compare(date, day.EndDate) == -1).FirstOrDefault();
        }
    }
}
