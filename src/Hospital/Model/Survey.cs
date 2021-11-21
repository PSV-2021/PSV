using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.Model
{
    public class Survey
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime Date { get; set; }
        public int AppointmentId { get; set; }
        public List<int> SurveyQuestions { get; set; }
        public List<int> SurveyAnswers { get; set; }
        public Survey() { }

        public Survey(int id, int patientId, DateTime date, int appointmentId, List<int> surveyQuestions, List<int> surveyAnswers) 
        {
            Id = id;
            PatientId = patientId;
            Date = date;
            AppointmentId = appointmentId;
            SurveyQuestions = surveyQuestions;
            SurveyAnswers = surveyAnswers;
        }
    }
}
