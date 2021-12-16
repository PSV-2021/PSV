using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hospital.MedicalRecords.Model;
using Hospital.RoomsAndEquipment.Model;
using Hospital.RoomsAndEquipment.Repository;
using Hospital.SharedModel;
using Newtonsoft.Json;

namespace Hospital.Schedule.Model
{
    public class Appointment : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationInMunutes { get; set; }
        public String ApointmentDescription { get; set; }
        public Boolean isCancelled { get; set; }
        public Boolean canCancel { get; set; }

        public Boolean IsDeleted { get; set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("SurveyId")]
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        [NotMapped]
        public AppointmentStatus Status { get; set; }

        //[JsonIgnore]
        //public Room Room { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        //public Boolean IsEmergency { get; set; }
        //public Note Note { get; set; }

        public bool IsOccupied(DateTime start)
        {
            return DateTime.Compare(StartTime, start) == 0;
        }
        public Appointment(int id, Patient patient, Doctor doctor, DateTime startTime, int duration, string apDesc/*, Note note, Boolean IsEmergency = false*/)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            //Room = room;
            StartTime = startTime;
            DurationInMunutes = duration;
            ApointmentDescription = apDesc;
            IsDeleted = false;
            //Note = note;
            //this.IsEmergency = IsEmergency;
        }

        public Appointment(Doctor doctor, DateTime startTime, Patient patient)
        {
            /*RoomFileRepository rs = new RoomFileRepository();
            List<Room> rooms = rs.GetAll();
            Room room = rooms[0];
            if (rooms.Count == 0)
            {
                room = null;
            }*/
            this.DurationInMunutes = 15;
            this.ApointmentDescription = "Pregled kod lekara opste prakse.";
            this.IsDeleted = false;
            this.Doctor = doctor;
            this.StartTime = startTime;
            this.Patient = patient;
        }
        [NotMapped]
        public DateTime EndTime
        {
            get
            {
                return StartTime.AddMinutes(DurationInMunutes);
            }
        }

        [NotMapped]
        public String BeginTime
        {
            get
            {
                return StartTime.ToString("dd.MM.yyyy hh:mm");
            }
        }


        [NotMapped]
        public String PatientName
        {
            get
            {
                if (Patient != null)
                    return (Patient.Name + " " + Patient.Surname);
                else
                    return "";
            }
        }
        /*[JsonIgnore]
        public String RoomName
        {
            get
            {
                if (Room != null)
                    return Convert.ToString(Room.RoomNumber);
                else
                    return "";
            }
            set
            {
                OnPropertyChanged("RoomName");
            }
        }*/
        [NotMapped]
        public String DoctorName
        {
            get
            {
                if (Doctor != null)
                    return (Doctor.Name + " " + Doctor.Surname);
                else
                    return "";
            }
            set
            {
                OnPropertyChanged("DoctorName");
            }
        }

        /* public String AppointmentDescription
         {
             get => ApointmentDescription;
             set
             {
                 ApointmentDescription = value;
                 OnPropertyChanged("AppointmentDescription");
             }
         }

         public DateTime StartTimee
         {
             get => StartTime;
             set
             {
                 StartTime = value;
                 OnPropertyChanged("StartTimee");
             }

         }*/

        public Appointment() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
