using Microsoft.AspNetCore.Mvc;
using RestFull.Models;

namespace RestFull.Repositories.Interfaces
{
    public interface IBookInterface
    {
        Task<List<Book>> GetAllBooks();
    }
}
