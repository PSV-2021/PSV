using System;
using System.Collections.Generic;
using System.Text;
using Integration.Model;

namespace Integration_API.Repository.Interfaces
{
    public interface IDrugstoreRepository : IGenericRepository<Drugstore, int>
    {
        List<Drugstore> SearchDrugstoresByCityAndAddress(string address, string city);
        string GetDrugstoreName(int id);
    }
}
