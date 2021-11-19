using System;
using System.Collections.Generic;
using System.Text;
using Integration.Model;

namespace Integration_API.Repository.Interfaces
{
    public interface IDrugstoreOfferRepository
    {
        public void Delete(int id);
        public List<DrugstoreOffer> GetAll();
        public void Save(DrugstoreOffer drugstoreOffer);

        public void Update(DrugstoreOffer drugstoreOffer);

    }
}
