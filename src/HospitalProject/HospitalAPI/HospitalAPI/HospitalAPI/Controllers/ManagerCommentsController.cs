using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Repository;
using Hospital.SharedModel;
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.Authorization;

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

        [AuthAttribute("Get", "manager")]
        [HttpGet]   // GET /api/comments
        public IActionResult Get()
        {
            IEnumerable<string> keyValues = Request.Headers.Keys.Select(key => key + ": " + string.Join(",", Request.Headers[key]));
            string requestHeaders = string.Join(System.Environment.NewLine, keyValues);
            Console.Out.WriteLine(requestHeaders);
            repoFeedback.dbContext = dbContext;
            List<UserFeedback> result = new List<UserFeedback>();
            result = repoFeedback.GetAll();
            return Ok(result);
        }

        [AuthAttribute("Post", "manager")]
        [HttpPost]   // POST /api/publishfeedback
        public IActionResult Post([FromBody] int id)
        {
            repoFeedback.dbContext = dbContext;
            UserFeedback matchedRecords = dbContext.UserFeedbacks.ToList().Find(matchedRecords => matchedRecords.Id == id);

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
