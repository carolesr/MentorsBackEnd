using MentorsBackEnd.Models;
using MentorsBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MentorsBackEnd.Controllers
{
    [Route("api/Purchase")]
    [ApiController]
    public class PurchaseController
    {
        private readonly PurchaseService _purchaseService;
        public PurchaseController(PurchaseService service)
        {
            _purchaseService = service;
        }
        [HttpGet]
        public string Index()
        {
            return "Hello World Purchase";
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Purchase>> Get() =>
            _purchaseService.GetAll();


        [HttpPost("Create")]
        public ActionResult<Purchase> Create(Purchase p)
        {
            return _purchaseService.Create(p);
        }
    }
}
