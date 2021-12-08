
using Drugstore.Models;
using Drugstore.Repository.Sql;
using DrugstoreAPI.Service;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Service;
using System.Threading.Tasks;

namespace DrugstoreAPI
{
    public class DrugDemandServiceGrpc : gRPCDrugPurchaseService.gRPCDrugPurchaseServiceBase
    {
        private readonly MyDbContext dbContext;
              
        private MedicineService medicineService;
        public HospitalService hospitalService;
        private readonly ILogger<GreeterService> _logger;
        public DrugDemandServiceGrpc(ILogger<GreeterService> logger)
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