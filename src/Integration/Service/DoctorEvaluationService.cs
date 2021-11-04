using Model;
using System;
using System.Collections.Generic;
using Integration_API.Repository.File;
using Integration_API.Repository.Interfaces;

namespace Service
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