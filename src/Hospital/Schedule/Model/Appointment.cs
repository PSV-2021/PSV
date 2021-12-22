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
        public int DurationInMunutes { get; private set; }
        public String ApointmentDescription { get; private set; }
        public Boolean isCancelled { get; private set; }
        public Boolean canCancel { get; private set; }
        public Boolean IsDeleted { get; private set; }

        [ForeignKey("DoctorId")]
        public int DoctorId { get; private set; }
        public virtual Doctor Doctor { get; }

        [ForeignKey("SurveyId")]
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; }
        [NotMapped]
        public AppointmentStatus Status { get; private set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; private set; }
        public virtual Patient Patient { get; }


        public bool IsOccupied(DateTime start)
        {
            return DateTime.Compare(StartTime, start) == 0;
        }
        public Appointment(int id, Patient patient, Doctor doctor, DateTime startTime, int duration, string apDesc)
        {
            Id = id;
            Patient = patient;
            Doctor = doctor;
            StartTime = startTime;
            DurationInMunutes = duration;
            ApointmentDescription = apDesc;
            IsDeleted = false;
        }

        public Appointment(Doctor doctor, DateTime startTime, Patient patient)
        {
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



        public Appointment() { }

        public Appointment(int id, DateTime date, int duration, int doctorId, int patientId)
        {
            Id = id;
            StartTime = date;
            DurationInMunutes = duration;
            DoctorId = doctorId;
            PatientId = patientId;
            Validate();
        }

        public Appointment(int id, DateTime date, int duration, string text, bool isDeleted, int doctorId, int patientId, bool isCancelled)
        {
            Id = id;
            StartTime = date;
            DurationInMunutes = duration;
            ApointmentDescription = text;
            IsDeleted = isDeleted;
            DoctorId = doctorId;
            PatientId = patientId;
            this.isCancelled = isCancelled;
            Validate();
        }

        public Appointment(int id, DateTime date, int duration, string text, bool isDeleted, int doctorId, int patientId, bool isCancelled, bool canCancel)
        {
            Id = id;
            StartTime = date;
            DurationInMunutes = duration;
            ApointmentDescription = text;
            IsDeleted = isDeleted;
            DoctorId = doctorId;
            PatientId = patientId;
            this.isCancelled = isCancelled;
            this.canCancel = canCancel;
            Validate();
        }

        public Appointment(DateTime start, int duration, string description, bool isDeleted, int doctorId, int patientId, bool isCancelled)
        {
            StartTime = start;
            DurationInMunutes = duration;
            ApointmentDescription = description;
            IsDeleted = isDeleted;
            DoctorId = doctorId;
            PatientId = patientId;
            this.isCancelled = isCancelled;
            Validate();
        }



        public Appointment(DateTime startTime, int doctorId)
        {
            StartTime = startTime;
            DoctorId = doctorId;
            Validate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public List<Appointment> StatusAppointment(List<Appointment> appointments)
        {
            foreach (Appointment a in appointments)
            {
                if (a.isCancelled)
                    a.Status = AppointmentStatus.CANCELLED;
                else if (a.StartTime < DateTime.Now)
                    a.Status = AppointmentStatus.DONE;
                else if (a.StartTime > DateTime.Now)
                    a.Status = AppointmentStatus.UPCOMING;

                if (a.StartTime.Day < DateTime.Now.Day + 3)
                    a.canCancel = false;
            }
            return appointments;
        }

        public bool CheckBeforeDate(DateTime startDate, DateTime minDate )
        {
            if (startDate >= minDate || startDate == DateTime.Now.Date)
                return true;
            return false;
        }


        public bool CheckAfterDate(DateTime afterDate, DateTime maxDate)
        {
            if (afterDate <= maxDate)
                return true;
            return false;
        }

        private void Validate()
        {
            if (Id < 0)
                throw new ArgumentException(String.Format("Id must be positive number"));
            if (PatientId < 0)
                throw new ArgumentException(String.Format("PatientId must be positive number"));
            if (DoctorId < 0)
                throw new ArgumentException(String.Format("DoctorId must be positive number"));
            if (SurveyId < 0)
                throw new ArgumentException(String.Format("SurveyId must be positive number"));
            if (DurationInMunutes < 0)
                throw new ArgumentException(String.Format("DurationInMunutes must be positive number"));
        }

        public void SetCancel(Appointment appointment)
        {
            appointment.isCancelled = true;
        }

    }
}
