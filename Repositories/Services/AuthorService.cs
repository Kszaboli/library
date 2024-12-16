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

        public async Task<string> AddNewAuthor(Author author)
        {
            var au = new Author()
            {
                AuthorName = author.AuthorName
            };
            if (au != null)
            {
                await _context.AddAsync(au);
                await _context.SaveChangesAsync();
                return "Új author sikeresen hozzáadva.";
            }
            Exception e = new();
            return e.Message;
        }

        public async Task<ActionResult<string>> Delete(int id)
        {
            var au = await _context.Authors.FirstOrDefaultAsync(a=>a.AuthorId==id);
            if (au != null)
            {
                _context.Authors.Remove(au);
                await _context.SaveChangesAsync();
                return "Törlés sikeres.";
            }
            return "Törlés sikertelen";
        }

        public async Task<List<Author>> GetAll()
        {
            var auth = await _context.Authors.ToListAsync();
            return auth;
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

        public async Task<Author> Put(int id, Author author)
        {
            var a = await _context.Authors.FirstOrDefaultAsync(au=>au.AuthorId==id);
            if(a != null)
            {
                a.AuthorName = author.AuthorName;

                _context.Authors.Update(a);
                await _context.SaveChangesAsync();

                return a;
            }
            return null;
        }

        Task<string> IAuthorInterface.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
