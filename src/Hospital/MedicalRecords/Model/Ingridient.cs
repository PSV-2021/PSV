using Hospital.SharedModel;
using System;
using System.Collections.Generic;

namespace Hospital.MedicalRecords.Model
{
    public class Ingridient : ValueObject
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Ingridient(string name) {
            this.Name = name;
        }

        public Ingridient(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Ingridient()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Name;
        }
    }
}