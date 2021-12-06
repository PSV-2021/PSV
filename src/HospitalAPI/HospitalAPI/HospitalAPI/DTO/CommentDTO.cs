using System;
using System.Collections.Generic;
using Hospital.MedicalRecords.Model;
using Hospital.SharedModel;

namespace HospitalAPI.DTO
{
    public class CommentDTO
    {
        public String Name { get; set; }
        public String Date { get; set; }
        public String Content { get; set; }

        public CommentDTO()
        {

        }
    }
}
