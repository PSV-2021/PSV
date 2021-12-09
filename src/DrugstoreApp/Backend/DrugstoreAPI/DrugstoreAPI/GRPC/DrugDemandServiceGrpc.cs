
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service;
using System.Threading.Tasks;

namespace DrugstoreAPI
{
    public class DrugDemandServiceGrpc : gRPCDrugPurchaseService.gRPCDrugPurchaseServiceBase
    {
        private MyDbContext dbContext;
              
        private MedicineService medicineService;
        public HospitalService hospitalService;
        private readonly ILogger<GreeterService> _logger;

        private void SetupDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();
            builder.UseNpgsql("server=localhost; port=5432; database=drugstore; User Id=postgres; password=12345");
            this.dbContext = new MyDbContext(builder.Options);
        }
        public DrugDemandServiceGrpc(ILogger<GreeterService> logger, MyDbContext dbContext)
        {
            
            _logger = logger;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.hospitalService = new HospitalService(new HospitalSqlRepository(dbContext));

        }
        public DrugDemandServiceGrpc(MyDbContext db) 
        {
            this.dbContext = db;
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.hospitalService = new HospitalService(new HospitalSqlRepository(dbContext));

        }
        public DrugDemandServiceGrpc() 
        {
            SetupDbContext();
            this.medicineService = new MedicineService(new MedicineSqlRepository(dbContext));
            this.hospitalService = new HospitalService(new HospitalSqlRepository(dbContext));
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
             
    }
}