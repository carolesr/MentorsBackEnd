using MentorsBackEnd.Models;
using MentorsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MentorsBackEnd.Hubs;

namespace MentorsBackEnd.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(UserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public string Index()
        {
            return "Welcome to User Controller";
        }

        [HttpGet("GetAll")]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("Get")]
        public ActionResult<User> Get(int id)
        {
            return _userService.Get(id);
        }

        [HttpPost("Create")]
        public ActionResult<User> Create(User u)
        {
            return _userService.Create(u);
        }

        [HttpGet("TesteSignalR")]
        public System.Threading.Tasks.Task TesteSignalR()
        {
            return _userService.SendNotificationAsync("teste");
        }
    }
}
