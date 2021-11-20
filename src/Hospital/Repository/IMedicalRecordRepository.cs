using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Repository
{
    interface IMedicalRecordRepository : IGenericRepository<MedicalRecord, int>
    {
    }
}
