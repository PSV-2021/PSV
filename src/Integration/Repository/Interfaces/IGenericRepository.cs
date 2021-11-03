using System;
using System.Collections.Generic;

namespace Integration_API.Repository.Interfaces
{
    public interface IGenericRepository<T, M> where T:class
    {
        List<T> GetAll();
        T GetOne(M id);
        Boolean Save(T newObject);
        Boolean Update(T editedObject);
        Boolean Delete(M id);
    }
}
