using Hospital.Schedule.Model;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Schedule.Repository
{
    public class AppointmentSqlRepository : IAppointmentRepository
    {
        public MyDbContext dbContext { get; set; }
        public AppointmentSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public AppointmentSqlRepository()
        {
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            return dbContext.Appointments.ToList();
        }

        public Appointment GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Appointment newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Appointment editedObject)
        {
            throw new NotImplementedException();
        }
    }
}
