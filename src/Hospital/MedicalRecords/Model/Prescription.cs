using System;
using Hospital.Medicines.Model;
using Hospital.SharedModel;
using Newtonsoft.Json;

namespace Hospital.MedicalRecords.Model
{
   public class Prescription
   {
       public int Id { get; set; }
       public string PatientName { get; set; }
       public string Description { get; set; }
       public string DrugName { get; set; }
       public DateTime IssuedTime { get; set; }

       public Prescription(int id,string patientName, string description, string drugName, DateTime issuedTime)
       {
           Id = id;
           PatientName = patientName;
           Description = description;
           DrugName = drugName;
           IssuedTime = issuedTime;
       }

        public Prescription(string patientName, string description, string drugName, DateTime issuedTime)
       {
           PatientName = patientName;
           Description = description;
           DrugName = drugName;
           IssuedTime = issuedTime;
       }

       /*
       public DateTime StartDate { get; set; }
        public int DurationInDays { get; set; }
        public Period ReferencePeriod { get; set; }
        public int Number { get; set; }
        public int Id { get; set; }
        public Boolean isActive { get; set; }

        public Medicine Medicine { get; set; }

        public Prescription(DateTime time, int d, Period rp, int n, int id, Boolean a, Medicine m)
        {
            this.StartDate = time;
            this.DurationInDays = d;
            this.ReferencePeriod = rp;
            this.Number = n;
            this.Id = id;
            this.isActive = a;
            this.Medicine = m;
        }
       */
   }
}