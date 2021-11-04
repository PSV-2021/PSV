using Drugstore.Models;
using System;
using System.Collections.Generic;
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
    }
}
