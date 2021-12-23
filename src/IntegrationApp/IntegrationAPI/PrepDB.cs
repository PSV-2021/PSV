
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;
using System;

namespace Integration_API
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                MyDbContext dbContext = serviceScope.ServiceProvider.GetService<MyDbContext>();
                Console.WriteLine("Applying Migration...");
                dbContext.Database.Migrate();
                Console.WriteLine("Migration done");
            }
        }
    }
}