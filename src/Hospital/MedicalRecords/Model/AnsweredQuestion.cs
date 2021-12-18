using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.MedicalRecords.Model
{
    public class AnsweredQuestion
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public int Rating { get; set; }
        public int QuestionType { get; set; }
        [ForeignKey("SurveyId")]
        public int SurveyId { get; set; }
        public virtual Survey survey { get;}

        public AnsweredQuestion() { }

        public AnsweredQuestion(String text, int rating, int questionType)
        {
            Text = text;
            Rating = rating;
            QuestionType = questionType;
        }

        public AnsweredQuestion(int id, string text, int rating, int type)
        {
            Id = id;
            Text = text;
            Rating = rating;
            QuestionType = type;
        }
    }
}
