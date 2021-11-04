using Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital;
using Hospital.Repository;
using Model;
using Hospital.DTO;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public UserFeedbackSqlRepository repoFeedback = new UserFeedbackSqlRepository();
      
        public CommentsController(MyDbContext db)
        {
            this.dbContext = db;
        }

        [HttpGet]   // GET /api/comments
        public IActionResult Get()
        {
            repoFeedback.dbContext = dbContext;
            List<CommentDTO> result = new List<CommentDTO>();
            result = repoFeedback.GetAllAproved();
            return Ok(result);
        }
    }
}
