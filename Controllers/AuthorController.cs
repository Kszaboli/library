using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull.Repositories.Interfaces;

namespace RestFull.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            this.authorInterface = authorInterface;
        }

        [HttpGet("feladat9")]
        public async Task<ActionResult> Get(string name)
        {
            var author = await authorInterface.GetByName(name);

            if (author != null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpGet("feladat12")]
        public async Task<ActionResult> NumOfAuth()
        {
            var num = await authorInterface.NumOfAuth();
            if (num != null)
            {
                return Ok(num);
            }return BadRequest();
        }
    }
}
