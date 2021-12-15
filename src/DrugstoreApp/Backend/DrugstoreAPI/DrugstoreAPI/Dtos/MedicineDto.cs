using Drugstore.Models;
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
        public String Manufacturer { get; set; }
        public String SideEffects { get; set; }
        public String Reactions { get; set; }
        public String Usage { get; set; }
        public List<Medicine> CompatibleMedicines { get; set; }
        public Double Weight { get; set; }
        public String Precautions { get; set; }
        public String Substances { get; set; }
        public String MedicineImage { get; set; }

        public MedicineDto() { }
    }
}
