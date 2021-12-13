using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Supply { get; set; }

        public Medicine(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Medicine(int id, String name, int supply)
        {
            this.Id = id;
            this.Name = name;
            this.Supply = supply;
        }
        public Medicine( String name, int supply)
        {          
            this.Name = name;
            this.Supply = supply;
        }

        public Medicine() { }
    }
}

