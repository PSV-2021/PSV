using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;

namespace Drugstore.Repository.Interfaces
{
    public interface IDrugstoreOfferRepository
    {
        public void Delete(int id);
        public List<DrugstoreOffer> GetAll();
        public void Save(DrugstoreOffer drugstoreOffer);

        public void Update(DrugstoreOffer drugstoreOffer);

        public DrugstoreOffer getById(string offerId);
    }
}
