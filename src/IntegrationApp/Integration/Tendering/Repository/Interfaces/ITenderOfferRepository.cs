using System;
using System.Collections.Generic;
using System.Text;
using Integration.Tendering.Model;
using Integration_API.Repository.Interfaces;

namespace Integration.Tendering.Repository.Interfaces
{
    interface ITenderOfferRepository : IGenericRepository<TenderOffer, int>
    {
    }
}
