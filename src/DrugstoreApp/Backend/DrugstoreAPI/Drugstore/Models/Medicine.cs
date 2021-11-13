using System;
using System.Collections.Generic;
using System.Text;

namespace Drugstore.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Double Price { get; set; }
        public int Supply { get; set; }

        public Medicine(int id, String name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        public Medicine(int id, String name, double price, int supply)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Supply = supply;
        }

        public Medicine() { }
    }
}
