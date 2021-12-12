using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Hospital.Medicines.Model
{
   public class Medicine
   {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public double Price { get; set; }
        public int Supply { get; set; }
        public String Manufacturer { get; set; }
        public string SideEffects { get; set; }
        public String Reactions { get; set; }
        public String Usage { get; set; }
        public Double Weight { get; set; }
        public String Precautions { get; set; }
        public String MedicineImage { get; set; }

        //******** Dodati deo - ako nesto ne radi
        /*
        public MedicineStatus Status { get; set; }
        public String Packaging { get; set; }
        public MedicineCondition Condition { get; set; }
        public Boolean IsDeleted { get; set; }

        public Medicine ReplacementMedicine { get; set; }

        public Medicine(String name, String manufacturer, String packaging, int id, MedicineCondition condition)
        {
            this.Id = id;
            this.Name = name;
            this.Manufacturer = manufacturer;
            this.Packaging = packaging;
            this.Condition = condition;
            this.Status = MedicineStatus.awaiting;
            this.ReplacementMedicine = null;
            //this.ingridient = new System.Collections.Generic.List<Ingridient>();
            this.IsDeleted = false;
        }
        */

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


        /*

        private System.Collections.Generic.List<Ingridient> ingridient;

        public System.Collections.Generic.List<Ingridient> Ingridient
        {
            get
            {
                if (ingridient == null)
                    ingridient = new System.Collections.Generic.List<Ingridient>();
                return ingridient;
            }
            set
            {
                RemoveAllIngridient();
                if (value != null)
                {
                    foreach (Ingridient oIngridient in value)
                        AddIngridient(oIngridient);
                }
            }
        }

        public void AddIngridient(Ingridient newIngridient)
        {
            if (newIngridient == null)
                return;
            if (this.ingridient == null)
                ingridient = new System.Collections.Generic.List<Ingridient>();
            if (!this.ingridient.Contains(newIngridient))
                this.ingridient.Add(newIngridient);
        }

        public void RemoveIngridient(Ingridient oldIngridient)
        {
            if (oldIngridient == null)
                return;
            if (this.ingridient != null)
                if (this.ingridient.Contains(oldIngridient))
                    this.ingridient.Remove(oldIngridient);
        }

        public void RemoveAllIngridient()
        {
            if (ingridient != null)
                ingridient.Clear();
        }
        */

        override
        public String ToString()
        {
            return Name;
        }

    }

}
