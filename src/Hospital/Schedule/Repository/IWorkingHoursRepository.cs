using Hospital.Schedule.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public interface IWorkingHoursRepository : IGenericRepository<WorkingHours, int>
    {
        public WorkingHours GetByDoctorAndDate(int id, DateTime date);
    }
}
