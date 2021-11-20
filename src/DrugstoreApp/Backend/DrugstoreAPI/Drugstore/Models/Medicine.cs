using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public int Supply { get; set; }
        public String Manufacturer { get; set; }
        public String SideEffects { get; set; }
        public String Reactions { get; set; }
        public String Usage { get; set; }
        public List<Medicine> compatibleMedicines { get; set; }
        public Double Weight { get; set; }
        public String Precautions { get; set; }

        public Medicine(int id, String name, double price, int supply)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Supply = supply;
        }

        public Medicine(int id, string name, double price, int supply, string manufacturer, string sideEffects, string reactions, string usage, List<Medicine> compatibleMedicines, double weight, string precautions) 
        {
            Id = id;
            Name = name;
            Price = price;
            Supply = supply;
            Manufacturer = manufacturer;
            SideEffects = sideEffects;
            Reactions = reactions;
            Usage = usage;
            this.compatibleMedicines = compatibleMedicines;
            Weight = weight;
            Precautions = precautions;
            Substances = substances;
        }

        public Medicine(int id, string name, string substances)
        {
            Id = id;
            Name = name;
            Substances = substances;
        }

        public Medicine() { }
    }
}
