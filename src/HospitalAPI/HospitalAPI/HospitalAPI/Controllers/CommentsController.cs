using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital;
using Hospital.MedicalRecords.Repository;
using Hospital.SharedModel;
using HospitalAPI.DTO;
using Hospital.MedicalRecords.Model;
using Hospital.MedicalRecords.Service;
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.Authorization;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public UserFeedbackSqlRepository repoFeedback = new UserFeedbackSqlRepository();
        public UserFeedbackService userFeedbackService = new UserFeedbackService();

        public CommentsController(MyDbContext db)
        {
            this.dbContext = db;
            userFeedbackService = new UserFeedbackService(new UserFeedbackSqlRepository(dbContext));

        }

        [AuthAttribute("Post", "patient")]
        [HttpPost]   // POST /api/comments
        public IActionResult Post([FromBody]CommentDTO comment)
        {
            Console.WriteLine(comment.Content);
            UserFeedback feedback = GenerateUserFeedbackFromDTO(comment);
            userFeedbackService.SaveUserFeedback(feedback);
            return Ok();
        }

        [AuthAttribute("Get", "patient")]
        [HttpGet]   // GET /api/comments
        public IActionResult Get()
        {
            repoFeedback.dbContext = dbContext;
            List<Hospital.DTO.CommentDTO> result = new List<Hospital.DTO.CommentDTO>();
            result = repoFeedback.GetAllAproved();
            return Ok(result);
        }

        

        private UserFeedback GenerateUserFeedbackFromDTO(CommentDTO comDTO)
        {
            UserFeedback comment = new UserFeedback(DateTime.Now, comDTO.Content, comDTO.Name, false);
          
            return comment;
        }
    }
}
