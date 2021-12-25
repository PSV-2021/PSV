using System;
using System.ComponentModel.DataAnnotations;
using Castle.Core.Internal;
using EllipticCurve.Utils;
using Newtonsoft.Json;
using String = System.String;

namespace Hospital.Medicines.Model
{
   public class Medicine
   {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Supply { get; set; }
        public string Manufacturer { get; set; }
        public string SideEffects { get; set; }
        public string Reactions { get; set; }
        public string Usage { get; set; }
        public double Weight { get; set; }
        public string Precautions { get; set; }
        public string MedicineImage { get; set; }

        public Medicine(int id, string name, double price, int supply, string manufacturer, string sideEffects, string reactions, string usage, double weight, string precautions, string medicineImage)
        {
            Id = id;
            Name = name;
            Price = price;
            Supply = supply;
            Manufacturer = manufacturer;
            SideEffects = sideEffects;
            Reactions = reactions;
            Usage = usage;
            Weight = weight;
            Precautions = precautions;
            MedicineImage = medicineImage;
        }

        public Medicine(string name, int supply)
        {
            Name = name;
            Supply = supply;
        }

        public Medicine()
        { }

        override
        public String ToString()
        {
            return Name;
        }

    }

}
