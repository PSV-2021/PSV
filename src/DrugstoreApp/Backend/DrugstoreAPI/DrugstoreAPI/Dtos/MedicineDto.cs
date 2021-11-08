using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Dtos
{
    public class MedicineDto
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public MedicineDto() { }
    }
}