using Hospital.RoomsAndEquipment.Model;
using Hospital.Schedule.Repository;

namespace Hospital.RoomsAndEquipment.Repository
{
    interface IEquipmentRepository: IGenericRepository<Equipment, int>
    {
    }
}
