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

        SurveyQuestion() { }
    }
}
