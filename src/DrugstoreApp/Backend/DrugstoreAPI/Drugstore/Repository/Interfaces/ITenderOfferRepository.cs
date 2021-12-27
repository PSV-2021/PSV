using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;
using Drugstore.Repository.Interfaces;

namespace Drugstore.Repository.Interfaces
{
    interface ITenderOfferRepository 
    {
        public List<TenderOffer> GetAll();
        public TenderOffer GetOne(int id);
        public void Add(TenderOffer drugTender);
        public bool Delete(int id);
        public TenderOffer GetByName(string name);
        public void Update(TenderOffer drugTender);
    }
}
