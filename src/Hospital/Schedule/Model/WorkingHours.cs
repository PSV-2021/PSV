// File:    WorkingHours.cs
// Author:  graho
// Created: ponedeljak, 17. maj 2021. 08.09.07
// Purpose: Definition of Class WorkingHours

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Schedule.Model
{
    public class WorkingHours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped]
        public Shift Shift { get; set; }

        public WorkingHours(DateTime beginningDate, Shift shift)
        {
            BeginningDate = beginningDate;
            EndDate = beginningDate.AddDays(6);
            Shift = shift;
        }
        public WorkingHours() { }

        public string FormatedBeginnigDate
        {
            get
            {
                return BeginningDate.ToString("dd.MM.yyyy.");
            }
        }
        public string FormatedEndDate
        {
            get
            {
                return EndDate.ToString("dd.MM.yyyy.");
            }
        }
        
        public string FormatedShift
        {
            get
            {
                if (Shift == Shift.firstShift)
                    return "07:00 - 14:00";
                if (Shift == Shift.secondShift)
                    return "14:00 - 21:00";
                return "";
            }
        }

    }
}