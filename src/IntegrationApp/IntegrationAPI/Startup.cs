using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Model.DataBaseContext;

using Grpc.Core;
using System;

namespace Integration_API
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private Server server;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddControllers();
            //services.AddHostedService<RabbitMQService>();
            services.AddDbContext<MyDbContext>(options =>
                options.UseNpgsql(GetDBConnectionString()).UseLazyLoadingProxies());
            services.AddControllersWithViews().AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                    
            }));
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseCors();
            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PrepDB.PrepPopulation(app);

            //server = new Server
            //{
            //    Services = { NetGrpcService.BindService(new NetGrpcServiceImpl()) },
            //    Ports = { new ServerPort("localhost", 4111, ServerCredentials.Insecure) }
            //};
            //server.Start();

            applicationLifetime.ApplicationStopping.Register(OnShutdown);
        }

        private string GetDBConnectionString()
        {
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "5432";
            var user = Configuration["DBUser"] ?? "postgres";
            var password = Configuration["DBPassword"] ?? "123";
            var database = Configuration["DB"] ?? "hospital";
            Console.WriteLine($"server={server}; port={port}; database={database}; User Id={user}; password={password}");
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }
        
        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }

        }
    }
}
