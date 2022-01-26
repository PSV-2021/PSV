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
        public FileNotificationService FileNotificationService;


        public NotificationController(MyDbContext db)
        {
            this.dbContext = db;
            this.FileNotificationService = new FileNotificationService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAllNotifications()
        {
            return Ok(FileNotificationService.GetAll());
        }

        [HttpPost]
        public IActionResult AddNotification(FileNotification notification)
        {
            if(notification.Title == null || notification.Content == null || notification.Title == string.Empty || notification.Content == string.Empty)
            {
                return NotFound("Notification is empty.");
            }
            FileNotificationService.Add(notification);
            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult RemoveNotification(FileNotification notification)
        {
            if(notification.Id == null)
            {
                return NotFound("Could not find notification specified.");
            }
            FileNotificationService.Delete(notification.Id);
            return Ok();
        }

        [HttpGet("refresh")]
        public IActionResult RefreshNotifications()
        {
            FileNotificationService.RefreshNotifications();
            return Ok();
        }

        [HttpPost("recieve")]
        public IActionResult Post(FileNotification newNotification)
        {
            Microsoft.Extensions.Primitives.StringValues headerValues;

            if (Request.Headers.TryGetValue("ApiKey", out headerValues))
            {
                // Can now check if the value is true:
                var value = Request.Headers["ApiKey"];
                foreach (string nesto in value)
                {
                    if (this.checkApiKey(nesto, dbContext))
                    {
                        FileNotificationSqlRepository repo = new FileNotificationSqlRepository();
                        repo.DbContext = dbContext;
                        repo.Save(newNotification);
                        return Ok(newNotification);
                    }
                }
            }
            return Unauthorized();
        }

        public bool checkApiKey(string apiKey, MyDbContext dbContext)
        {
            bool found = false;
            foreach (Hospital h in dbContext.Hospitals.ToList())
            {
                if (h.ApiKey.Equals(apiKey))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
