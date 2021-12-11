using Drugstore.Models;
using Drugstore.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI
{
   
    public class Program
    {
        public static void Main(string[] args)
        {
            FileCompressionService fcs = new FileCompressionService();
            fcs.CompressOldFiles();
            CreateHostBuilder(args).Build().Run();
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
