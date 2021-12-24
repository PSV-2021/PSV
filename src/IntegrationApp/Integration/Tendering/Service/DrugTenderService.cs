using System.Collections.Generic;
using System.Linq;
using Integration.Repository.Sql;
using Integration.Tendering.Model;
using Integration.Tendering.Repository.Sql;
using Model.DataBaseContext;
using Syncfusion.XPS;

namespace Integration.Service
{
    public class DrugTenderService
    {
        public DrugTenderSqlRepository drugTenderRepository { get; set; }
        public TenderOfferSqlRepository TenderOfferSqlRepository { get; set; }

        public DrugTenderService(MyDbContext dbContext)
        {
            drugTenderRepository = new DrugTenderSqlRepository(dbContext);
            TenderOfferSqlRepository = new TenderOfferSqlRepository(dbContext);
        }

        public void Save(DrugTender tender)
        {
            drugTenderRepository.Save(tender);
        }

        public List<DrugTender> GetOngoingTenders()
        {
            return drugTenderRepository.GetAll().Where(tender => !tender.isFinished).ToList();
        }

        public List<TenderOffer> GetOffersForTender(int tenderId)
        {
            return TenderOfferSqlRepository.GetAll().Where(offer => offer.TenderId == tenderId).ToList();
        }

    }
}
