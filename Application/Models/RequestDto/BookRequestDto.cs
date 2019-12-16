using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.RequestDto
{
	public class BookRequestDto
	{
		public string Title { get; set; }
		public string Language { get; set; }
		public DateTime PublishedAt { get; set; }
		public int IdPublisher { get; set; }
		public int IdAuthor { get; set; }
	}
}
