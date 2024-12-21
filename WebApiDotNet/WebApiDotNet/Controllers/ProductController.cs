using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDotNet.Models;

namespace WebApiDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ITIContext context;
        public ProductController(ITIContext _context)
        {
            context = _context;
            
        }
        [HttpGet] //api/department
        public IActionResult GetAll()
        {
            List<Product> product = context.Products.ToList();
            return Ok(product);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Product product = context.Products.FirstOrDefault(x=> x.Id == id);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return CreatedAtAction("GetById", new { id = product.Id }, product);
            //return Created($"http://localhost:3143/api/product/{product.Id}",product);

        }
    }
}
