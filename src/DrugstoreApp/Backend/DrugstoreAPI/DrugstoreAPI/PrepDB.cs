using Drugstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder)
        {
            using(var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                MyDbContext dbContext= serviceScope.ServiceProvider.GetService<MyDbContext>();
                EventDbContext eventDbContext = serviceScope.ServiceProvider.GetService<EventDbContext>();
                Console.WriteLine("Applying Migration..");
                dbContext.Database.Migrate();
            }
        }
    }
}
