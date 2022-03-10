using System;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;

namespace Hospital.Schedule.Service
{
   public class DoctorEvaluationService
   {
        private IDoctorEvaluationRepository DoctorEvaluationRepository { get; set; }
        public DoctorEvaluationService()
        {
            DoctorEvaluationRepository = new DoctorEvaluationFileRepository();
        }

        public Boolean SaveEvaluation(DoctorEvaluation newEvaluation)
        {
            return DoctorEvaluationRepository.Save(newEvaluation);
        }
    }
}