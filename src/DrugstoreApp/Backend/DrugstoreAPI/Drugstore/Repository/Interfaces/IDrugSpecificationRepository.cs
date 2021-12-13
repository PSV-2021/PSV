using System;
using System.Collections.Generic;
using System.Text;
using Drugstore.Models;

namespace Drugstore.Repository.Interfaces
{
    public interface IDrugSpecificationRepository
    {
        public void Delete(int id);
        public List<DrugSpecification> GetAll();
        public void Save(DrugSpecification drugSpecification);

        public void Update(DrugSpecification drugSpecification);

        public DrugSpecification getById(string offerId);
    }
}
