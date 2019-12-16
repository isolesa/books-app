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
    [Route("publishers")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public readonly IQueries _queries;
        public PublishersController(IQueries queries){
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        // GET: publishers
        [HttpGet]
        public async Task<IActionResult> GetPublishers()
        {
            var result = await _queries.GetPublishersAsync();
            return Ok(result);
        }

        // GET: publishers/id
        [HttpGet("{id}", Name = "GetPublisherById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var result = await _queries.GetPublisherByIdAsync(id);
            
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: publishers
        [HttpPost]
        public async Task<IActionResult> InsertPublisher([FromBody] PublisherRequestDto publisherRequest)
        {
            var result = await _queries.InsertPublisherAsync(publisherRequest);

            if (result > 0)
            {
                PublisherResponseDto publisherResponse = await _queries.GetPublisherByIdAsync(result);
                return CreatedAtAction(nameof(GetPublisherById), new { Id = result }, publisherResponse);
            }
            return BadRequest();
        }

        // PUT: publishers/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePublisher(int id, [FromBody] PublisherRequestDto publisherRequest)
        {
            var result = await _queries.UpdatePublisherAsync(id, publisherRequest);
            
            if (result > 0)
            {
                PublisherResponseDto publisherResponse = await _queries.GetPublisherByIdAsync(id);
                return Ok(publisherResponse);
            }
            return BadRequest();
        }

        // DELETE: publishers/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var result = await _queries.DeletePublisherAsync(id);

            if(result > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
