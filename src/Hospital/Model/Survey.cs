using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Model
{
    public class Survey
    {
        public int Id { get; set; }
        public List<SurveyQuestion> SurveyQuestions { get; set; }
        public String Jmbg { get; set; }
        public DateTime Date { get; set; }
        Survey() { }
    }
}
