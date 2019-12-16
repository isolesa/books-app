using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.ResponseDto
{
	public class BookResponseDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Language { get; set; }
		public DateTime PublishedAt { get; set; }
		public DateTime CreatedAt { get; set; }
		public int IdPublisher { get; set; }
		public string Author { get; set; }
	}
}
