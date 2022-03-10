// File:    VacationDays.cs
// Author:  graho
// Created: ponedeljak, 17. maj 2021. 08.17.58
// Purpose: Definition of Class VacationDays

using System;

namespace Hospital.Schedule.Model
{
    public class VacationDays
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationDays(DateTime start, DateTime end)
        {
            StartDate = start;
            EndDate = end;
        }
        public VacationDays() { }
        public string FormatedStartDate
        {
            get
            {
                return StartDate.ToString("dd.MM.yyyy.");
            }
        }
        public string FormatedEndDate
        {
            get
            {
                return EndDate.ToString("dd.MM.yyyy.");
            }
        }

    }
}