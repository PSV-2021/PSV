using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HospitalApiTests.Integration
{
    public class SurveySqlRepositoryTests
    {
        private MyDbContext context;
        public void SetUpDbContext()
        {
            DbContextOptionsBuilder<MyDbContext> builder = new DbContextOptionsBuilder<MyDbContext>();

            builder.UseNpgsql(Constants.ConnectionString);

            context = new MyDbContext(builder.Options);
        }

        [Fact]
        public void Get_surveys()
        {
            SetUpDbContext();
            ISurveyRepository surveySqlRepository = new SurveySqlRepository(context);

            List<Survey> retVal = surveySqlRepository.GetAll();

            retVal.Equals(Surveys());
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Appointment_id_exist(int id)
        {
            SetUpDbContext();
            ISurveyRepository surveySqlRepository = new SurveySqlRepository(context);
            SurveyService service = new SurveyService(surveySqlRepository);

            bool retVal = service.CheckIfExistsById(id);

            retVal.ShouldBeTrue();
        }

        public static IEnumerable<object[]> Surveys()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { new Survey(1, new List<SurveyQuestion>(), 1, DateTime.Now, 1) });
            return retVal;

        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { 1 });
            return retVal;

        }
    }
}
