using Integration.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                MyDbContext dbContext = serviceScope.ServiceProvider.GetService<MyDbContext>();
                Console.WriteLine("Applying Migration..");
                //dbContext.Database.Migrate();
            }
        }
    }
}