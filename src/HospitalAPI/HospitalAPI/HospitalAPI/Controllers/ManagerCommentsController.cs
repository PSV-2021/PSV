using Hospital.Model;
using Hospital.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
