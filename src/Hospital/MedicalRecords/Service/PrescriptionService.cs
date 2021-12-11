using System;
using System.Collections.Generic;
using System.Text;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Service
{
    public class PrescriptionService
    {
        public IPrescriptionRepository PrescriptionRepository { get; set; }

        public PrescriptionService(MyDbContext dbContext)
        {
            PrescriptionRepository = new PrescriptionSqlRepository(dbContext);
        }

        public void SaveNewPrescription(Prescription prescription)
        {
            PrescriptionRepository.Save(prescription);
        }


    }
}
