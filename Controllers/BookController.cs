﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestFull.Models;
using RestFull.Repositories.Interfaces;

namespace RestFull.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface bookInterface;

        public BookController(IBookInterface bookInterface)
        {
            this.bookInterface = bookInterface;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await bookInterface.GetAllBooks();

            if (books != null)
            {
                return Ok(books);
            }
            return BadRequest();
        }
    }
}