using System.Collections.Generic;
using System.Linq;
using Integration.Repository.Sql;
using Integration.Tendering.Model;
using Model.DataBaseContext;
using Syncfusion.XPS;

namespace Integration.Service
{
    public class DrugTenderService
    {
        public DrugTenderSqlRepository drugTenderRepository { get; set; }

        public DrugTenderService(MyDbContext dbContext)
        {
            drugTenderRepository = new DrugTenderSqlRepository();
            drugTenderRepository.dbContext = dbContext;
        }

        public void Save(DrugTender tender)
        {
            drugTenderRepository.Save(tender);
        }

        public List<DrugTender> GetOngoingTenders()
        {
            return drugTenderRepository.GetAll().Where(tender => !tender.isFinished).ToList();
        }

    }
}
