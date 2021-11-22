using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class DrugSpecificationRequestDTO
    {
        public string PharmacyUrl { get; set; }
        public string Name { get; set; }

        DrugSpecificationRequestDTO() { }

        DrugSpecificationRequestDTO(string pharmacyUrl, string drugName)
        {
            this.PharmacyUrl = pharmacyUrl;
            this.Name = drugName;
        }
    }
}
