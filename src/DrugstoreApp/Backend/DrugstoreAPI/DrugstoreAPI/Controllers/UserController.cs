using Drugstore.Models;
using Drugstore.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService userService;

        public UserController(MyDbContext context)
        {
            this.userService = new UserService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(userService.GetAll());
        }

        [HttpGet("{username?}")]
        public IActionResult Get(String username)
        {
            User user = userService.GetOne(username);
            if (user == null) return NotFound();
            else return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            userService.Add(user);
            return Ok();
        }


        [HttpPost]
        public IActionResult LogIn(User user)
        {
            if (userService.Login(user))
            {
                return Ok();
            }
            else return NotFound();
        }
    }
}
