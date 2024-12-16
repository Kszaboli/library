using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull.Models;
using RestFull.Repositories.Interfaces;

namespace RestFull.Repositories.Services
{
    public class AuthorService : IAuthorInterface
    {
        private readonly LibrarydbContext _context;

        public AuthorService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Author>> GetByName(string name)
        {
            var author = await _context.Authors.Include(aut=>aut.Books)
                .FirstOrDefaultAsync(auth=>auth.AuthorName==name);
            return author;
        }
        public async Task<string> NumOfAuth()
        {
            var num = await _context.Authors.CountAsync();
            return num.ToString();
        }
    }
}
