using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.SharedModel
{
    public class Speciality
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Speciality(int id, string n)
        {
            this.Id = id;
            this.Name = n;
            Validate();
        }
        public Speciality() { }

        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));
        }
    }
}