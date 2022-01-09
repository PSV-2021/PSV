using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Integration.Repository.Sql;
using Integration_API.Repository.Interfaces;

namespace Integration_API.Factory
{
    class SqlRepositoryFactory : IRepositoryFactory
    {
        public IDrugstoreRepository CreateDrugstoreRepository()
        {
            return new DrugstoreSqlRepository();
        }

        public IDrugstoreFeedbackRepository CreateDrugstoreFeedbackRepository()
        {
            return new DrugstoreFeedbackSqlRepository();
        }
    }
}
