using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models.RequestDto
{
	public class PublisherRequestDto
	{
		public string Name { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public DateTime Founded { get; set; }
	}
}
