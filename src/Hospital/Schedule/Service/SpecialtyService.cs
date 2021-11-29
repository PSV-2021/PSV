using Hospital.Schedule.Model;
using Hospital.Schedule.Repository;
using Hospital.SharedModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Schedule.Service
{
    public class SpecialtyService
    {
        private ISpecialtyRepository SpecialtyRepository { get; }

        public SpecialtyService(SpecialtySqlRepository specialtySqlRepository)
        {
            SpecialtyRepository = specialtySqlRepository;
        }

        public List<Speciality> GetAllSpecialty()
        {
            return SpecialtyRepository.GetAll();
        }
    }
}
