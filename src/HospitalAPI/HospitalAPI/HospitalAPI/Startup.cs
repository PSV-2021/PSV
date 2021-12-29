using Grpc.Core;
using Hospital.SharedModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace HospitalAPI
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
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => Configuration.Bind("JwtSettings", options));
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("QKcOa8xPopVOliV6tpvuWmoKn4MOydSeIzUt4W4r1UlU2De7dTUYMlrgv3rU"));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  

            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });



            services.AddControllers();
            services.AddDbContext<MyDbContext>(options =>
            options.UseNpgsql(GetDBConnectionString()).UseLazyLoadingProxies());
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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

            app.UseCors("MyPolicy");

            app.UseAuthentication();  //dodato

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            PrepDB.PrepPopulation(app);
            server = new Server
            {
                Services = { Greeter.BindService(new GreeterService()), gRPCDrugPurchaseService.BindService(new DrugDemandServiceGrpc()) },
                Ports = { new ServerPort(Configuration["HOSPITAL_GRPC_DOMAIN"] ?? "localhost", int.Parse(Configuration["HOSPITAL_GRPC_PORT"] ?? "4112"), ServerCredentials.Insecure) }
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
            var password = Configuration["DBPassword"] ?? "natasa1234";
            var database = Configuration["DB"] ?? "hospitalNewN";
            Console.WriteLine(server + port + user + password + database);
            if (server == null) return ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString");
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }

    }   
 }

