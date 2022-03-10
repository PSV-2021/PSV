using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Castle.Core.Internal;
using Hospital.SharedModel;
using Microsoft.EntityFrameworkCore;

namespace Hospital.MedicalRecords.Model
{
    [Owned]
    public class MedicalRecord : ValueObject
    {
        public String HealthInsuranceNumber { get; private set; }
        public String CompanyName { get; private set; }
        public MedicalRecord(string hid, string cmpName)
        {
            this.HealthInsuranceNumber = hid;
            this.CompanyName = cmpName;
            Validate();
        }

        private void Validate()
        {
            if (HealthInsuranceNumber.IsNullOrEmpty() || CompanyName.IsNullOrEmpty())
                throw new ArgumentException("Some of arguments of medical record are not set!");
        }

        public MedicalRecord() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return HealthInsuranceNumber;
            yield return CompanyName;
        }
    }
}