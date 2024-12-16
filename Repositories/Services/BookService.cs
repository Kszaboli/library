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

        public async Task<string> AddNewBook(string id, Book book)
        {
            string uid = "FKB3F4FEA09CE43C";
            if (uid == id)
            {
                var bk = new Book()
                {
                    Title = book.Title,
                    PublishDate = DateTime.Now,
                    AuthorId = book.AuthorId,
                    CategoryId = book.CategoryId,
                };
                if (bk != null)
                {
                    await _context.AddAsync(bk);
                    await _context.SaveChangesAsync();
                    return "Új könyv hozzadása sikeres.";
                }
                Exception e = new();
                return e.Message;
            }
            return "Nincs jogosultsága új könyv felviteléhez.";
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}
