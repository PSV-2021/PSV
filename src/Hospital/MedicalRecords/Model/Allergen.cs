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
        }
    }
}
