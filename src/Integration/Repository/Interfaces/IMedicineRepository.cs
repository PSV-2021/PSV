using System.Collections.Generic;
using Model;

namespace Integration_API.Repository.Interfaces
{
    public interface IMedicineRepository:IGenericRepository<Medicine, int>
    {
        List<Medicine> GetAwaiting();
        List<Medicine> GetApproved();
    }
}
