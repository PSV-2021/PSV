using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class Survey
    {
        public int Id { get; set; }
        public virtual List<SurveyQuestion> SurveyQuestions { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public int AppointmentId { get; set; }
        public Survey() { }

        public Survey(int id, List<SurveyQuestion> surveyQuestions, int patientId, DateTime date, int appointmentId) 
        {
            Id = id;
            SurveyQuestions = surveyQuestions;
            PatientId = patientId;
            Date = date;
            AppointmentId = appointmentId;
        }
    }
}
