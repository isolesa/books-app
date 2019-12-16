using Application.Models.RequestDto;
using Application.Models.ResponseDto;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class Queries : IQueries
	{
        private readonly IConfiguration _configuration;
        public Queries(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public SqlConnection Connection
        {
            get
            {
                var builder = new SqlConnectionStringBuilder(_configuration.GetConnectionString("BooksDatabase"));
                return new SqlConnection(builder.ConnectionString);
            }
        }

        // All books
        public async Task<IEnumerable<BookResponseDto>> GetBooksAsync()
        {
            var sql = "spBooks_GetBooks";

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<BookResponseDto>(sql, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        // Book by id
        public async Task<BookResponseDto> GetBookByIdAsync(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            
            var sql = "spBooks_GetBook";
            
            parameters.Add("id", id);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                BookResponseDto bookResponse = await connection.QueryFirstOrDefaultAsync<BookResponseDto>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return bookResponse;
            }
        }

        // Adding new book
        public async Task<int> InsertBookAsync(BookRequestDto bookRequest)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = "spBooks_InsertBook";
            
            parameters.Add("Title", bookRequest.Title);
            parameters.Add("Language", bookRequest.Language);
            parameters.Add("PublishedAt", bookRequest.PublishedAt);
            parameters.Add("CreatedAt", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
            parameters.Add("IdPublisher", bookRequest.IdPublisher);
            parameters.Add("IdAuthor", bookRequest.IdAuthor);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        // All authors
        public async Task<IEnumerable<AuthorResponseDto>> GetAuthorsAsync()
        {
            var sql = @"SELECT * 
                        FROM Authors";

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<AuthorResponseDto>(sql, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Author by id
        public async Task<AuthorResponseDto> GetAuthorByIdAsync(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"SELECT * 
                        FROM Authors 
                        WHERE Id = @Id";

            parameters.Add("Id", id);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.QueryFirstOrDefaultAsync<AuthorResponseDto>(sql, parameters, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Adding new author
        public async Task<int> InsertAuthorAsync(AuthorRequestDto authorRequest)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"INSERT INTO Authors 
                        VALUES(@FirstName, @LastName, @DateOfBirth) 
                        SELECT SCOPE_IDENTITY()";

            parameters.Add("FirstName", authorRequest.FirstName);
            parameters.Add("LastName", authorRequest.LastName);
            parameters.Add("DateOfBirth", authorRequest.DateOfBirth);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Updating author by id
        public async Task<int> UpdateAuthorAsync(int id, AuthorRequestDto authorRequest)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"UPDATE Authors 
                        SET FirstName = @FirstName,
                            LastName = @LastName,
                            DateOfBirth = @DateOfBirth
                            OUTPUT INSERTED.Id
                        WHERE Id = @Id";

            parameters.Add("FirstName", authorRequest.FirstName);
            parameters.Add("LastName", authorRequest.LastName);
            parameters.Add("DateOfBirth", authorRequest.DateOfBirth);
            parameters.Add("Id", id);

            using(var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Deleting author by id
        public async Task<int> DeleteAuthorAsync(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"DELETE FROM Authors 
                        WHERE Id = @Id";

            parameters.Add("Id", id);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        // All publishers
        public async Task<IEnumerable<PublisherResponseDto>> GetPublishersAsync()
        {
            var sql = @"SELECT * 
                        FROM Publishers";

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<PublisherResponseDto>(sql, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Publisher by id
        public async Task<PublisherResponseDto> GetPublisherByIdAsync(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"SELECT * 
                        FROM Publishers 
                        WHERE Id = @Id";

            parameters.Add("Id", id);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.QueryFirstOrDefaultAsync<PublisherResponseDto>(sql, parameters, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Adding new publisher
        public async Task<int> InsertPublisherAsync(PublisherRequestDto publisherRequest)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"INSERT INTO Publishers 
                        VALUES (@Name, @City, @Country, @Founded) 
                        SELECT SCOPE_IDENTITY()";

            parameters.Add("Name", publisherRequest.Name);
            parameters.Add("City", publisherRequest.City);
            parameters.Add("Country", publisherRequest.Country);
            parameters.Add("Founded", publisherRequest.Founded);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Updating publisher by id
        public async Task<int> UpdatePublisherAsync(int id, PublisherRequestDto publisherRequest)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"UPDATE Publishers 
                        SET Name = @Name,
                            City = @City,
                            Country = @Country,
                            Founded = @Founded
                            OUTPUT INSERTED.Id
                        WHERE Id = @Id";

            parameters.Add("Name", publisherRequest.Name);
            parameters.Add("City", publisherRequest.City);
            parameters.Add("Country", publisherRequest.Country);
            parameters.Add("Founded", publisherRequest.Founded);
            parameters.Add("Id", id);

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteScalarAsync<int>(sql, parameters, commandType: System.Data.CommandType.Text);
                return result;
            }
        }

        // Deleting publisher by id
        public async Task<int> DeletePublisherAsync(int id)
        {
            DynamicParameters parameters = new DynamicParameters();

            var sql = @"DELETE FROM Publishers 
                        WHERE Id = @Id";

            parameters.Add("id", id);

            using(var connection = Connection)
            {
                await connection.OpenAsync();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

    }
}