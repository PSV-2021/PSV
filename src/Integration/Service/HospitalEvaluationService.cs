using Model;
using System;
using Integration_API.Repository.File;
using Integration_API.Repository.Interfaces;

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