using Drugstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugstore.Repository.Sql
{
    public class MedicineSqlRepository
    {
        public MyDbContext DbContext { get; set; }

        public MedicineSqlRepository(MyDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public MedicineSqlRepository()
        {
        }

        public List<Medicine> GetAll()
        {
            List<Medicine> result = new List<Medicine>();
            DbContext.Medicines.ToList().ForEach(medicine => result.Add(new Medicine(medicine.Id, medicine.Name, medicine.Price)));

            return result;
        }

    }
}
