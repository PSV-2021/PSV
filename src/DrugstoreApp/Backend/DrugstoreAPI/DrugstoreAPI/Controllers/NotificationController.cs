using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using DrugstoreAPI.Filters;
using RestSharp;
using Drugstore.Models;
using Service;
using DrugstoreAPI.Models;
using Drugstore.Repository.Sql;
using Drugstore.Service;
using DrugstoreAPI.DTOs;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")] // /api/DrugstoreFeedbackWithAPI
    [ApiController]

    public class NotificationController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public NotificationService NotificationService;


        public NotificationController(MyDbContext db) //Ovo mora da stoji, ne znam zasto!!!
        {
            this.dbContext = db;
            this.NotificationService = new NotificationService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            return Ok(NotificationService.GetAll());
        }
        [HttpPost]
        public IActionResult AddNotification(Notification notification)
        {
            if(notification.Title == null || notification.Content == null || notification.Title == string.Empty || notification.Content == string.Empty)
            {
                return NotFound("Notification is empty.");
            }
            NotificationService.Add(notification);
            return Ok();
        }
        [HttpPost("remove")]
        public IActionResult RemoveNotification(Notification notification)
        {
            if(notification.Id == null)
            {
                return NotFound("Could not find notification specified.");
            }
            NotificationService.Delete(notification.Id);
            return Ok();
        }
    }
}
