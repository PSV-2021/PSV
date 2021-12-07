using Hospital.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public interface IWorkingHoursRepository : IGenericRepository<WorkingHours, int>
    {
        public List<WorkingHours> GetAll();
        public WorkingHours GetByDoctorAndDate(int id, DateTime date);
    }
}
