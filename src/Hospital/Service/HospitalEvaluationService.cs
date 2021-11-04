using Model;
using System;
using Repository;

namespace Service
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