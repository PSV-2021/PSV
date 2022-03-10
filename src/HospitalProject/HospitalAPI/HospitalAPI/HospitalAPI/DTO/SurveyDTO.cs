using System.Collections.Generic;

namespace HospitalAPI.DTO
{
    public class SurveyDto
    {
        public List<int> SurveyQuestions { get; set; }
        public List<int> SurveyAnswers { get; set; }

        public SurveyDto()
        {

        }
    }
}
