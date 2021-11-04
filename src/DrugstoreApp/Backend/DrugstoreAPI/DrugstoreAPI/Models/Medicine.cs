using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Models
{
    public class Medicine
    {
        public long Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }

        public Medicine(int id, String name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public Medicine() { }
    }
}
