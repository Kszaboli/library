using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull.Models;
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

        [HttpDelete("Delete")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var result = await authorInterface.Delete(id);
            if (result.Contains("sikeres"))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Book>> Put(int id, Author author)
        {
            var result = await authorInterface.Put(id, author);
            if (result != null)
            {
                return Ok(author);
            }
            return NotFound();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var auths = await authorInterface.GetAll();

            if (auths != null)
            {
                return Ok(auths);
            }
            return BadRequest();
        }        
    }
}
