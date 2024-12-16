using Microsoft.AspNetCore.Mvc;
using RestFull.Models;

namespace RestFull.Repositories.Interfaces
{
    public interface IAuthorInterface
    {
        Task<ActionResult<Author>> GetByName(string name);
        Task<string> NumOfAuth();
        Task<List<Author>> GetAll();
        Task<string> AddNewAuthor(Author author);
        Task<Author> Put(int id, Author author);
        Task<string> Delete(int id);
    }
}
