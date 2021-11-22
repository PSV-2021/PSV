using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Dtos
{
    public class DrugSpecificationDto
    {
        public string Name { get; set; }

        public DrugSpecificationDto() { }

        public DrugSpecificationDto(string drugName)
        {
            this.Name = drugName;
        }
    }
}
