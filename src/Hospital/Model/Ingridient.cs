using System;

namespace Model
{
    public class Ingridient
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public Ingridient(string name) {
            this.Name = name;
        }

        public Ingridient(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}