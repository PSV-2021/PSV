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
        public int Supply { get; set; }
        public String MedicineImage { get; set; }


        public MedicineDto() { }
    }
}