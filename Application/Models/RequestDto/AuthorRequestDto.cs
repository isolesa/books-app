using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.RequestDto
{
	public class AuthorRequestDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
