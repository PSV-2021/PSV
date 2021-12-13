using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Drugstore.Models
{
    public class DrugSpecification
    {   
       [Key]
        public string Name { get; set; }
        public string Text { get; set; }

        public DrugSpecification()
        {
        }

        public DrugSpecification(string name, string text)
        {
            Name = name;
            Text = text;
        }

    }
}
