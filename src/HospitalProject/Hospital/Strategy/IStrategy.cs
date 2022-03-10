using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.RoomsAndEquipment.Model;

namespace Strategy
{
    public interface IStrategy
    {
        int ChangeEquipmentQuantity(RoomInventory roomInventory, int roomNumber, int inputItemQuantity, DateTime pickedDate);
    }
}
