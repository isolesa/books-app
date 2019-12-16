using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.RequestDto;
using Application.Models.ResponseDto;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IQueries _queries;
        public AuthorsController(IQueries queries)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        // GET: authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var result = await _queries.GetAuthorsAsync();
            return Ok(result);
        }

        // GET: authors/id
        [HttpGet("{id}", Name = "GetAuthorById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var result = await _queries.GetAuthorByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: authors
        [HttpPost]
        public async Task<IActionResult> InsertAuthor([FromBody] AuthorRequestDto authorRequest)
        {
            var result = await _queries.InsertAuthorAsync(authorRequest);

            if (result > 0)
            {
                AuthorResponseDto authorResponse = await _queries.GetAuthorByIdAsync(result);
                return CreatedAtAction(nameof(GetAuthorById), new { Id = result }, authorResponse);
            }
            return BadRequest();
        }

        // PUT: authors/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorRequestDto authorRequest)
        {
            var result = await _queries.UpdateAuthorAsync(id, authorRequest);
            
            if (result > 0)
            {
                AuthorResponseDto authorResponse = await _queries.GetAuthorByIdAsync(id);
                return Ok(authorResponse);
            }
            return BadRequest();
        }

        // DELETE: authors/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _queries.DeleteAuthorAsync(id);

            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
