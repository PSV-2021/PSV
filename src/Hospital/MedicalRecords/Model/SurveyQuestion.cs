using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.MedicalRecords.Model
{
    public class SurveyQuestion : ValueObject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Text { get; set; }
        public int Rating { get; set; }
        public int QuestionType { get; set; }

        public SurveyQuestion() { }

        public SurveyQuestion(String text, int rating, int questionType) 
        {
            Text = text;
            Rating = rating;
            QuestionType = questionType;
        }

        public SurveyQuestion(int id, string text, int rating, int type)
        {
            Id = id;
            Text = text;
            Rating = rating;
            QuestionType = type;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return Text;
            yield return Rating;
            yield return QuestionType;
        }
    }
}
