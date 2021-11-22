using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.SharedModel
{
    public class Speciality
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public Speciality(int id, string n)
        {
            this.Id = id;
            this.Name = n;
        }
        public Speciality() { }

    }
}