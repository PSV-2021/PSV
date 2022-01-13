
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service;
using System;
using System.Threading.Tasks;
using Drugstore.Service;

namespace DrugstoreAPI
{
    public class DrugDemandServiceGrpc : gRPCDrugPurchaseService.gRPCDrugPurchaseServiceBase
    {
        private MyDbContext dbContext;
              
        private MedicineService medicineService;
        public HospitalService hospitalService;
        public MailService mailService;
        private readonly ILogger<GreeterService> _logger;

        private void SetupDbContext(string connectionString)
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql(connectionString);
            this.dbContext = new MyDbContext(builder.Options);
        }
        public DrugDemandServiceGrpc(ILogger<GreeterService> logger, MyDbContext dbContext)
        {
            
            _logger = logger;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.hospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
            this.mailService = new MailService(new HospitalSqlRepository(dbContext));

        }
        public DrugDemandServiceGrpc(MyDbContext db) 
        {
            this.dbContext = db;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.hospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
            this.mailService = new MailService(new HospitalSqlRepository(dbContext));

        }
        public DrugDemandServiceGrpc() 
        {
            SetupDbContext(GetDBConnectionString());
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.hospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
            this.mailService = new MailService(new HospitalSqlRepository(dbContext));
        }

        public override Task<DrugReply> DrugDemand(DrugRequest request, ServerCallContext context)
        {
            if (request.ApiKey != null && request.ApiKey != "")
            {
                if (hospitalService.CheckApiKey(request.ApiKey))
                {
                    if (medicineService.CheckForAmountOfDrug(request.Name, request.Amount))
                    {
                        return Task.FromResult(new DrugReply
                        {
                            Message = "you can have some " + request.Name,
                            IsOk = true
                        });
                    }
                    return Task.FromResult(new DrugReply
                    {
                        Message = "you can't have some " + request.Name,
                        IsOk = false
                    });
                }
            }
            return Task.FromResult(new DrugReply
            {
                Message = "unauthorized ",
                IsOk = false
            });

        }

        public override Task<DrugReply> DrugPurchase(DrugRequest request, ServerCallContext context)
        {
            if (request.ApiKey != null && request.ApiKey != "")
            {
                if (hospitalService.CheckApiKey(request.ApiKey))
                {
                    if (medicineService.CheckForAmountOfDrug(request.Name, request.Amount))
                    {
                        medicineService.SellDrugUrgent(request.Name, request.Amount);
                        mailService.SendEmailAboutUrgentPurchase(request.Name, request.Amount, request.ApiKey);
                        return Task.FromResult(new DrugReply
                        {
                            Message = "you sold some " + request.Name,
                            IsOk = true
                        });
                    }
                    return Task.FromResult(new DrugReply
                    {
                        Message = "you can't sell some " + request.Name,
                        IsOk = false
                    });
                }
            }
            return Task.FromResult(new DrugReply
            {
                Message = "unauthorized ",
                IsOk = false
            });

        }
        
        public string GetDBConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DBServer") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DBPort") ?? "5432";
            var user = Environment.GetEnvironmentVariable("DBUser") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DBPassword") ?? "firma4";
            var database = Environment.GetEnvironmentVariable("DB") ?? "drugstore";
            
            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }

    }
}