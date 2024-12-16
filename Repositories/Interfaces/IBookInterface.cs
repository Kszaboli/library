using Microsoft.AspNetCore.Mvc;
using RestFull.Models;

namespace RestFull.Repositories.Interfaces
{
    public interface IBookInterface
    {
        Task<List<Book>> GetAllBooks();
        Task<string> AddNewBook(string id, Book book);
    }
}
