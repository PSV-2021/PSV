using System;
using System.Collections.Generic;
using System.Text;

namespace Integration.Model
{
    public class Drug
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Supply { get; set; }

        public Drug(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Drug(int id, String name, int supply)
        {
            this.Id = id;
            this.Name = name;
            this.Supply = supply;
        }
        public Drug( String name, int supply)
        {          
            this.Name = name;
            this.Supply = supply;
        }

        public Drug() { }
    }
}

