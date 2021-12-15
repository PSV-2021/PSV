using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_API.DTOs
{
    public class DrugstoreEditDto
    {
        public int Id { get; set; }
        public string ImageBase64 { get; set; }
        public string Comment { get; set; }

        public DrugstoreEditDto() { }

        public DrugstoreEditDto(int id, string imageBase64, string comment)
        {
            Id = id;
            ImageBase64 = imageBase64;
            Comment = comment;
        }
    }
}
