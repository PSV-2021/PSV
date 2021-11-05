using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrugstoreAPI.Dtos;
using DrugstoreAPI.Models;

namespace DrugstoreAPI.Adapters
{
    public class MedicineAdapter
    {
        public static Medicine MedicineDtoToMedicine(MedicineDto dto)
        {
            Medicine medicine = new Medicine();
            medicine.Name = dto.Name;
            medicine.Price = dto.Price;
            return medicine;
        }

        public static MedicineDto MedicineToMedicineDto(Medicine medicine)
        {
            MedicineDto dto = new MedicineDto();
            dto.Name = medicine.Name;
            dto.Price = medicine.Price;
            return dto;
        }
    }
}
