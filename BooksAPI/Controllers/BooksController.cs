using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.RequestDto;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IQueries _queries;
        public BooksController(IQueries queries)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        // GET: books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var result = await _queries.GetBooksAsync();
            return Ok(result);
        }

        // GET: books/id
        [HttpGet("{id}", Name = "GetBookById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetBookById(int id)
        {
            var result = await _queries.GetBookByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: books
        [HttpPost]
        public async Task<IActionResult> InsertBook([FromBody] BookRequestDto bookRequest)
        {
            var result = await _queries.InsertBookAsync(bookRequest);
            if (result > 0)
            {
                return CreatedAtAction(nameof(GetBookById), new { Id = result }, bookRequest);
            }
            return BadRequest();
        }

        // PUT: books/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: books/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
