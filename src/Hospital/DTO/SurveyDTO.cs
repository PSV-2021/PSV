using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hospital.DTO
{
    public class SurveyDTO
    {
        public List<int> SurveyQuestions { get; set; }
        public List<int> SurveyAnswers { get; set; }

        public SurveyDTO()
        {

        }
    }
}
