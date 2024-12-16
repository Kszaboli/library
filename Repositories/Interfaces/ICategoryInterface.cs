using Microsoft.AspNetCore.Mvc;
using RestFull.Models;

namespace RestFull.Repositories.Interfaces
{
    public interface ICategoryInterface
    {
        Task<List<Category>> GetAllWithBooks();
    }
}
