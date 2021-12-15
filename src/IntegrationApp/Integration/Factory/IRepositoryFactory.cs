using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integration_API.Repository.Interfaces;

namespace Factory
{
    interface IRepositoryFactory
    {
        IDrugstoreRepository CreateDrugstoreRepository();
        IDrugstoreFeedbackRepository CreateDrugstoreFeedbackRepository();
    }
}
