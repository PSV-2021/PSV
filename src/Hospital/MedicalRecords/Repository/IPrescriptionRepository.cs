using System;
using System.Collections.Generic;
using System.Text;
using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;

namespace Hospital.MedicalRecords.Repository
{
    public interface IPrescriptionRepository: IGenericRepository<Prescription, int>
    {
    }
}
