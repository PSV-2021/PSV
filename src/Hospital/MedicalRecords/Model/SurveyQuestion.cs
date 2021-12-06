using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.MedicalRecords.Model
{
    public class SurveyQuestion
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

    }
}
