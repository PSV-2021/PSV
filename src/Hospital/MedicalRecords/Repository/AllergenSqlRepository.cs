using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.MedicalRecords.Repository
{
    public class AllergenSqlRepository : IAllergenRepository
    {
        public MyDbContext dbContext { get; set; }

        public AllergenSqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public AllergenSqlRepository() { }
        

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Allergen> GetAll()
        {
            throw new NotImplementedException();
        }

        public Allergen GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Allergen newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Allergen editedObject)
        {
            throw new NotImplementedException();
        }

        public List<string> GetByIdPatient(int id)
        {
            List<string> listAllergiesOfPatient = new List<string>();
            try
            {
                listAllergiesOfPatient = (from n in dbContext.Allergens where n.PatientId == id select n.Name).ToList();
                if (dbContext.Allergens != null)
                {
                    Console.WriteLine(dbContext.Allergens.Find(1));
                    listAllergiesOfPatient = (from c in dbContext.Allergens where c.PatientId == id select c.Name).ToList();
                };
            }
            catch(Exception e)
            {
                
            }
            return listAllergiesOfPatient;
        }
    }
}
