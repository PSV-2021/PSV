
using Hospital.Medicines.Model;
using Hospital.Medicines.Service;
using Hospital.Medicines.Repository.Sql;
using Hospital.Service;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Hospital.SharedModel;
using System;

namespace HospitalAPI
{
    public class DrugDemandServiceGrpc : gRPCDrugPurchaseService.gRPCDrugPurchaseServiceBase
    {
        private MyDbContext dbContext;

        private DrugService medicineService;
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
            this.medicineService = new DrugService(dbContext);

        }
        public DrugDemandServiceGrpc(MyDbContext db)
        {
            this.dbContext = db;
            this.medicineService = new DrugService(dbContext);

        }
        public DrugDemandServiceGrpc()
        {
            SetupDbContext(GetDBConnectionString());
            this.medicineService = new DrugService(dbContext);
        }

        public override Task<DrugReply> DrugPurchase(DrugRequest request, ServerCallContext context)
        {
            medicineService.AddDrugUrgent(request.Name, request.Amount);
            return Task.FromResult(new DrugReply
            {
                Message = "you bought some " + request.Name,
                IsOk = true
            });

        }
        public string GetDBConnectionString()
        {
            var server = Environment.GetEnvironmentVariable("DBServer") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("DBPort") ?? "5432";
            var user = Environment.GetEnvironmentVariable("DBUser") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("DBPassword") ?? "firma4";
            var database = Environment.GetEnvironmentVariable("DB") ?? "hospitalNew";

            return $"server={server}; port={port}; database={database}; User Id={user}; password={password}";
        }

    }
}