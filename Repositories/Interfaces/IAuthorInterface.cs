using Microsoft.AspNetCore.Mvc;
using RestFull.Models;

namespace RestFull.Repositories.Interfaces
{
    public interface IAuthorInterface
    {
        Task<ActionResult<Author>> GetByName(string name);
        Task<string> NumOfAuth();
    }
}
