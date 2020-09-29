using MentorsBackEnd.Models;
using MentorsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return "Hello World User";
        }

        [HttpGet("GetAll")]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpPost("CreateUser")]
        public ActionResult<User> CreateUser(User u)
        {
            return _userService.CreateUser(u);
        }

        [HttpPost("DeleteUser")]
        public void DeleteUser(int idCard)
        {
            _userService.DeleteUser(idCard);
        }

        [HttpPost("VerifyUser")]
        public void VerifyUser([FromBody] int idCard)
        {
            _userService.VerifyUser(idCard);
        }

        [HttpGet("TesteSignalR")]
        public void TesteSignalR()
        {
            _userService.TesteSignalR("teste");
        }
    }
}
