using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.SharedModel;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerCommentsController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public UserFeedbackSqlRepository repoFeedback = new UserFeedbackSqlRepository();

        public ManagerCommentsController(MyDbContext db)
        {
            this.dbContext = db;
        }

        [HttpGet]   // GET /api/comments
        public IActionResult Get()
        {
            repoFeedback.dbContext = dbContext;
            List<UserFeedback> result = new List<UserFeedback>();
            result = repoFeedback.GetAll();
            return Ok(result);
        }

        [HttpPost]   // POST /api/publishfeedback
        public IActionResult Post([FromBody] int id)
        {
            repoFeedback.dbContext = dbContext;
            UserFeedback matchedRecords = dbContext.UserFeedback.ToList().Find(matchedRecords => matchedRecords.Id == id);

            if (matchedRecords != null)
            {
                if (matchedRecords.canPublish == true)
                {
                    matchedRecords.canPublish = false;
                }
                else
                {
                    matchedRecords.canPublish = true;
                }
                dbContext.SaveChanges();
            }
            else
            {
                return Ok(false);
            }
            return Ok(true);
        }
    }
}
