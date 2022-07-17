using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.DTO
{
    public class CommentDTO
    {
        public String Name { get; set; }
        public DateTime Date { get; set; }
        public String Content { get; set; }

        public CommentDTO() { 

        }
    }
}
