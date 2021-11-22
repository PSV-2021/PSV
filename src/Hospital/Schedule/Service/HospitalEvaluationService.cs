using System;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;

namespace Hospital.Schedule.Service
{
   public class HospitalEvaluationService
   {
        private IHospitalEvaluationRepository HospitalEvaluationRepository { get; set; }
        public HospitalEvaluationService()
        {
            HospitalEvaluationRepository = new HospitalEvaluationFileRepository();
        }

        public Boolean SaveEvaluation(HospitalEvaluation newEvaluation)
        {
            return HospitalEvaluationRepository.Save(newEvaluation);
        }

        
    }
}