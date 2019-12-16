using Application.Models.RequestDto;
using Application.Models.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public interface IQueries
	{
		// Books
		Task<IEnumerable<BookResponseDto>> GetBooksAsync();
		Task<BookResponseDto> GetBookByIdAsync(int id);
		Task<int> InsertBookAsync(BookRequestDto bookRequest);

		// Authors
		Task<IEnumerable<AuthorResponseDto>> GetAuthorsAsync();
		Task<AuthorResponseDto> GetAuthorByIdAsync(int id);
		Task<int> InsertAuthorAsync(AuthorRequestDto authorRequest);
		Task<int> UpdateAuthorAsync(int id, AuthorRequestDto authorRequest);
		Task<int> DeleteAuthorAsync(int id);

		// Publishers
		Task<IEnumerable<PublisherResponseDto>> GetPublishersAsync();
		Task<PublisherResponseDto> GetPublisherByIdAsync(int id);
		Task<int> InsertPublisherAsync(PublisherRequestDto publisherRequest);
		Task<int> UpdatePublisherAsync(int id, PublisherRequestDto publisherRequest);
		Task<int> DeletePublisherAsync(int id);
	}
}
