using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Grpc.Core;
using Drugstore.Compression.Controller;
using Drugstore.Service;
using PrimerServis;

namespace DrugstoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private Server server;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHostedService<RabbitMQService>();
            services.AddDbContext<Drugstore.Models.MyDbContext>(options =>
            options.UseNpgsql(GetDBConnectionString()));
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSingleton<IHostedService, BackgroundCompressionController>();


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    
            }));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllers();
            });
            PrepDB.PrepPopulation(app);
            Console.WriteLine("SFTP_IP:" + Environment.GetEnvironmentVariable("SFTP_IP"));
            server = new Server
            {
                Services = { Greeter.BindService(new GreeterService()), gRPCDrugPurchaseService.BindService(new DrugDemandServiceGrpc()) },
                Ports = { new ServerPort(Configuration["DRUGSTORE_GRPC_DOMAIN"] ?? "localhost", int.Parse(Configuration["DRUGSTORE_GRPC_PORT"] ?? "4111"), ServerCredentials.Insecure) }
            };
            server.Start();
            applicationLifetime.ApplicationStopping.Register(OnShutdown);
        }
     
        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }
        }

        public string GetDBConnectionString()
        {
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "5432";
            var user = Configuration["DBUser"] ?? "postgres";
            var password = Configuration["DBPassword"] ?? "123";
            var database = Configuration["DB"] ?? "drugstore";
            if (server == null) return ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString");
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }
        

    }
}
