using Integration.Model;
using Integration_API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Repository.Interfaces
{
    interface IDrugsConsumptionRepository : IGenericRepository<DrugConsumed, int>
    {
    }
}
