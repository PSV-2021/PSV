using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Hospital.SharedModel;

namespace Hospital.MedicalRecords.Model
{
    public class MedicalRecord : ValueObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String HealthInsuranceNumber { get; set; }

        public MedicalRecord(int id, string hid)
        {
            this.Id = id;
            this.HealthInsuranceNumber = hid;
        }
        public MedicalRecord() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return HealthInsuranceNumber;
        }
    }
}