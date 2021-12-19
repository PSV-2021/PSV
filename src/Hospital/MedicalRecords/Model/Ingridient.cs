using Hospital.SharedModel;
using System;
using System.Collections.Generic;

namespace Hospital.MedicalRecords.Model
{
    public class Ingridient : ValueObject
    {
        public int Id { get; private set; }
        public String Name { get; private set; }

        public Ingridient(string name) {
            this.Name = name;
        }

        public Ingridient(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            Validate();
        }

        public Ingridient()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Name;
        }

        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));
        }
    }
}