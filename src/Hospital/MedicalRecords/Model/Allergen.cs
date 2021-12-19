using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.MedicalRecords.Model
{
    public class Allergen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Name { get; set; }
        [ForeignKey("PatientId")]
        public int PatientId {get; set; }
        public virtual Patient Patient { get; }
        public Allergen() { }

        public Allergen(int id, string s)
        {
            Id = id;
            Name = s;
            Validate();
        }

        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));
            if (PatientId < 0)
                throw new ArgumentException(String.Format("PatientId must be positive number"));
        }
    }
}
