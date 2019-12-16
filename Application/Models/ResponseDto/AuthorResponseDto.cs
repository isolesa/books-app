using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.ResponseDto
{
	public class AuthorResponseDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
