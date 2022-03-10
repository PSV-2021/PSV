// File:    HospitalTreatment.cs
// Author:  graho
// Created: ponedeljak, 17. maj 2021. 09.25.05
// Purpose: Definition of Class HospitalTreatment

using System;
using Hospital.RoomsAndEquipment.Model;

namespace Hospital.SharedModel
{
   public class HospitalTreatment
   {
      public DateTime StartDate { get; set; }
      public int DurationInDays { get; set; }

      public Room Room { get; set; }

      public HospitalTreatment(DateTime startDate, int durationInDays, Room room)
      {
          StartDate = startDate;
          DurationInDays = durationInDays;
          Room = room;
      }
    }
}