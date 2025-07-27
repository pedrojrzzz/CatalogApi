using CatalogAPI.Domain.Entities;
using CatalogAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CatalogAPI.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _dbContext;


        public CategoriesController(AppDbContext dbContext) 
        {
            _dbContext = dbContext; 
        }



        // Get All
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = _dbContext.Categories.ToList(); // We are accessing the Categories properties
            if (categories is null)
            {
                return NotFound("Products not found");
            }

            return categories;
        }


        // Get category products
        [HttpGet("products")] // Define a product route so it doesn't conflict with the first GET route
        public ActionResult<IEnumerable<Category>> GetCategoryProducts()
        {
            return _dbContext.Categories.Include(item => item.Products).ToList();
        }



        [HttpGet("{id:int}", Name = "GetCategory")] // Receiving a parameter via url
        public ActionResult<Category> Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(item => item.CategoryId == id);
            if (category is null)
            {
                return NotFound("Product not found");
            }
            return category;
        }



        [HttpPost]
        public ActionResult<Category> Post(Category category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return CreatedAtRoute("GetCategory", 
                new { id = category.CategoryId },
                category
            );
        }



        [HttpPut("{id:int}")]
        public ActionResult<Category> Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _dbContext.Entry(category).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return CreatedAtRoute("GetCategory",
                new { id = category.CategoryId },
                category
                );

        }

        [HttpDelete("{id:int}")]
        public ActionResult<Category> Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(item => item.CategoryId == id);

            if (category is null)
            {
                return BadRequest();
            }

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return Ok(category);
        }
    }
}
