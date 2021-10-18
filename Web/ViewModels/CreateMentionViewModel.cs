using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
	public class CreateMentionViewModel
	{
		public int UserID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public MentionCategory MentionCategory { get; set; }
		public string Image { get; set; }
		public IFormFile File { get; set; }
	}
}
