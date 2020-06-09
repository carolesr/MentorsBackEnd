//using Microsoft.AspNetCore.Components;
using MentorsBackEnd.Models;
using MentorsBackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpGet("Get{id}")]
        //[Route("teste/")]
        public ActionResult<Product> Get(int id)
        {
            return _productService.Get(id);
        }

    }
}
