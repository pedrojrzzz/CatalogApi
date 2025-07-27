using CatalogAPI.Domain.Entities;
using CatalogAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
         private  readonly AppDbContext _dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _dbContext.Products.ToList(); // We are accessing the Products properties
            if (products is null)
            {
                return NotFound("Products not found");
            }
                
            return products;
        }

        [HttpGet("{id:int}", Name = "GetProduct")] // Receiving a parameter via url
        public ActionResult<Product> Get(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(item => item.ProductId == id);
                if (product is null)
            {
                return NotFound("Product not found");
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (product is null)
            {
                return BadRequest(); // Return status code 400
            }
            _dbContext.Products.Add(product); // Sends the new product to the context but does not save anything in the database, it remains saved in memory
            _dbContext.SaveChanges(); // This line commits all pending changes to the database.

            // Returns an HTTP 201 Created response with the location of the newly created product
            return CreatedAtRoute(
                "GetProduct", // The name of the route to use ("GetProduct" is the name given in [HttpGet(Name = "GetProduct")])
                new { id = product.ProductId }, // Route values: sets the 'id' parameter in the route to the newly created product's ID
                product // The body of the response: returns the created product as JSON
            );
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return NoContent(); // Returns a status code of 204, it is successful but has no return value

        }

        [HttpDelete("{id:int}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(item => item.ProductId == id);
            if (product is null)
            {
                return NotFound("Product not found");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return Ok(product);
        }
    }
}
