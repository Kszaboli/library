using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestFull.Models;
using RestFull.Repositories.Interfaces;

namespace RestFull.Repositories.Services
{
    public class BookService : IBookInterface
    {
        private readonly LibrarydbContext _context;
        public BookService(LibrarydbContext context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}
