using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DataBaseContext;
using Integration.Repository.Sql;
using Integration_API.Repository.Interfaces;
using DrugstoreAPI.Controllers;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace Integration_API
{
    public class Program
    {
       
   
        public static void Main(string[] args)
        {
           
            CreateHostBuilder(args).Build().Run();
            

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureServices((hostContext, services) =>
                //{
                //    services.AddHostedService<ClientScheduledService>();
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });   


    }
}
