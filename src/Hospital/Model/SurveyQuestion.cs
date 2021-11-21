using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class SurveyQuestion
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public int Rating { get; set; }
        public int QuestionType { get; set; }

        public SurveyQuestion() { }

        public SurveyQuestion(int id, String text, int rating, int questionType) 
        {
            Id = id;
            Text = text;
            Rating = rating;
            QuestionType = questionType;
        }

    }
}
