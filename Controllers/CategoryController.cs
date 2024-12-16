using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull.Repositories.Interfaces;

namespace RestFull.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryInterface categoryInterface;

        public CategoryController(ICategoryInterface categoryInterface)
        {
            this.categoryInterface = categoryInterface;
        }

        [HttpGet("Feladat11")]
        public async Task<ActionResult> GetAllWithBooks()
        {
            var categs = await categoryInterface.GetAllWithBooks();
            if (categs != null)
            {
                return Ok(categs);
            }
            return BadRequest();
        }
    }
}
