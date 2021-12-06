using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class PrescriptionDto
    {
        public string PharmacyUrl { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string PatientName { get; set; }

        public PrescriptionDto()
        { }

        public PrescriptionDto(string url, string name,int amount, string description, string patienName)
        {
            PharmacyUrl = url;
            Name = name;
            Amount = amount;
            Description = description;
            PatientName = patienName;
        }


    }
}