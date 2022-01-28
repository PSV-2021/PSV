using Integration.Models;
using Integration.Notifications.Model;
using Integration.Service;
using Microsoft.AspNetCore.Mvc;
using Model.DataBaseContext;
using RestSharp;

namespace Integration_API.Controllers
{
    [Route("api/[controller]")] // /api/IntegrationFeedbackWithAPI
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
        public IActionResult AddNotification(FileNotification notification)
        {
            if (notification.Title == null || notification.Content == null || notification.Title == string.Empty || notification.Content == string.Empty || notification.DrugstoreName == null)
            {
                return NotFound("Notification is empty.");
            }
            NotificationService.Add(notification);
            return Ok();
        }

        [HttpPost("remove")]
        public IActionResult RemoveNotification(FileNotification notification)
        {
            if (notification.Id == null)
            {
                return NotFound("Could not find notification specified.");
            }
            NotificationService.Delete(notification.Id);
            return Ok();
        }

        [HttpGet("refresh")]
        public IActionResult RefreshNotifications()
        {
            NotificationService.RefreshNotifications();
            return Ok();
        }
    }
}
