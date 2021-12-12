
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
            SetupDbContext("server=localhost; port=5432; database=hospitalNew; User Id=postgres; password=firma4");
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

    }
}