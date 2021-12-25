using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.MedicalRecords.Service
{
    public class MedicalRecordService
    {
        private MedicalRecordSqlRepository MedicalRecordSqlRepository { get; set; }
        private PatientSqlRepository patientSqlRepository { get; set; }


        public MedicalRecordService(MedicalRecordSqlRepository medicalrecordSqlRepository)
        {
            MedicalRecordSqlRepository = medicalrecordSqlRepository;
        }

        public MedicalRecordService()
        {
        }
    }
}
