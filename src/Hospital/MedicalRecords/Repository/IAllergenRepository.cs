using Hospital.MedicalRecords.Model;
using Hospital.Schedule.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.MedicalRecords.Repository
{
    public interface IAllergenRepository: IGenericRepository<Allergen, int>
    {
    }
}
