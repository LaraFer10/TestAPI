using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("v1")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public HomeController(ProductService productService, CategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return  _productService.GetProducts();
        }

        [Route("products/{id:int}")]
        [HttpGet]
        public ActionResult<Product> GetProduct(int id)
        {
            var product =  _productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [Route("products")]
        [HttpPost]
        public void PostProduct(Product product)
        {
            _productService.Create(product);
        }

        [Route("categories")]
        [HttpPost]
        public void PostCategory(Category category)
        {
            _categoryService.Create(category);
        }

        [Route("categories/{id:int}")]
        public Category GetCategory(int id)
        {
            return _categoryService.GetCategory(id);
        }

        [Route("products/{id:int}")]
        [HttpGet]
        public IEnumerable<Product> GetByCategory(int id)
        {
            return _productService.GetByCategory(id);
        }

        /*/ PUT: api/Products/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }*/
    }
}
