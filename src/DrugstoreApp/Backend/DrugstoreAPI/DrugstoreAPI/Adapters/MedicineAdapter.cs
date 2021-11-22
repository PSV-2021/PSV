
using Drugstore.Models;
using DrugstoreAPI.Dtos;

namespace DrugstoreAPI.Adapters
{
    public class MedicineAdapter
    {
        public static Medicine MedicineDtoToMedicine(MedicineDto dto)
        {
            Medicine medicine = new Medicine();
            medicine.Name = dto.Name;
            medicine.Price = dto.Price;
            medicine.Supply = dto.Supply;
            return medicine;
        }

        public static MedicineDto MedicineToMedicineDto(Medicine medicine)
        {
            MedicineDto dto = new MedicineDto();
            dto.Name = medicine.Name;
            dto.Price = medicine.Price;
            dto.Supply = medicine.Supply;
            return dto;
        }
    }
}