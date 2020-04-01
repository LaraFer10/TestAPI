using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private readonly WebApplication1Context _context;

        public ProductService(WebApplication1Context context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products
                .Include(obj => obj.Category)
                .AsNoTracking()
                .ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products
                .Include(obj => obj.Category)
                .AsNoTracking()
                .FirstOrDefault(obj => obj.Id == id);
        }

        public IEnumerable<Product> GetByCategory(int id)
        {
            return _context.Products
                .Include(obj => obj.Category)
                .Where(obj => obj.CategoryId == id)
                .AsNoTracking()
                .ToList();
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
