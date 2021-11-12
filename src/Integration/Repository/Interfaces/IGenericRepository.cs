using System;
using System.Collections.Generic;

namespace Integration_API.Repository.Interfaces
{
    public interface IGenericRepository<T, M> where T:class
    {
        List<T> GetAll();
        T GetOne(M id);
        void Save(T newObject);
        void Update(T editedObject);
        void Delete(M id);
    }
}
