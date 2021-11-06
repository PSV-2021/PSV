using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration_API.Repository.Interfaces;

namespace Factory
{
    class FileRepositoryFactory : IRepositoryFactory
    {
        public IDrugstoreFeedbackRepository CreateDrugstoreFeedbackRepository()
        {
            throw new NotImplementedException();
        }

        public IDrugstoreRepository CreateDrugstoreRepository()
        {
            throw new NotImplementedException();
        }


    }
}
