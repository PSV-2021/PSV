using System;
using System.Collections.Generic;
using System.Text;
using Factory;
using Integration.Repository.Interfaces;
using Integration.Repository.Sql;

namespace Integration.Factory
{
    class SqlRepositoryFactory : IRepositoryFactory
    {
        public IAnnouncementRepository CreateAnnouncementRepository()
        {
            throw new NotImplementedException();
        }

        public IAppointmentRepository CreateAppointmentRepository()
        {
            throw new NotImplementedException();
        }

        public IDeclinedMedicineRepository CreateDeclinedMedicineRepository()
        {
            throw new NotImplementedException();
        }

        public IDoctorEvaluationRepository CreateDoctorEvaluationRepository()
        {
            throw new NotImplementedException();
        }

        public IDoctorRepository CreateDoctorRepository()
        {
            throw new NotImplementedException();
        }

        public IEquipmentRepository CreateEquipmentRepository()
        {
            throw new NotImplementedException();
        }

        public IEventsLogRepository CreateEventsLogRepository()
        {
            throw new NotImplementedException();
        }

        public IHospitalEvaluationRepository CreateHospitalEvaluationRepository()
        {
            throw new NotImplementedException();
        }

        public IMedicineRepository CreateMedicineRepository()
        {
            throw new NotImplementedException();
        }

        public IPatientRepository CreatePatientRepository()
        {
            throw new NotImplementedException();
        }

        public IRoomInventoryRepository CreateRoomInventoryRepository()
        {
            throw new NotImplementedException();
        }

        public IRoomRepository CreateRoomRepository()
        {
            throw new NotImplementedException();
        }

        public IUserFeedbackRepository CreateUserFeebackRepository()
        {
            throw new NotImplementedException();
        }

        //////////////////////////////////////////////
        public IDrugstoreRepository CreateDrugstoreRepository()
        {
            return new DrugstoreSqlRepository();
        }

        public IDrugstoreFeedbackRepository CreateUserFeedbackRepository()
        {
            return new DrugstoreFeedbackSqlRepository();
        }
    }
}
