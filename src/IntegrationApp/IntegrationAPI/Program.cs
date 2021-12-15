using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
