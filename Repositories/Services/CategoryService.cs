using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull.Models;
using RestFull.Repositories.Interfaces;

namespace RestFull.Repositories.Services
{
    public class CategoryService : ICategoryInterface
    {
        private readonly LibrarydbContext _context;

        public CategoryService(LibrarydbContext context)
        {
            _context = context;
        }

        public Task<List<Category>> GetAllWithBooks()
        {
            var categs = _context.Categories.Include(cat => cat.Books).ToListAsync();
            return categs;
        }
    }
}
