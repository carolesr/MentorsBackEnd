using MentorsBackEnd.Models;
using MentorsBackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MentorsBackEnd.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController
    {      
        private readonly ProductService _productService;

        public ProductController(ProductService service)
        {
            _productService = service;
        }

        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Product>> Get() =>
            _productService.GetAll();


        [HttpGet("Get/{id}")]
        public ActionResult<Product> Get(string id)
        {
            return _productService.Get(id);
        }

    }
}
