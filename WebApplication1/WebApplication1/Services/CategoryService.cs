using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CategoryService
    {
        private readonly WebApplication1Context _context;

        public CategoryService(WebApplication1Context context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(obj => obj.Id == id);
        }

        public void Create(Category category)
        {
             _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
