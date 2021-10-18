using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Web.ViewModels
{
	public class CreateMentionViewModel
	{
		public int UserID { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Titel")]
		public string Title { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Beschrijving")]
		public string Description { get; set; }

		public MentionCategory MentionCategory { get; set; }

		public string Image { get; set; }

		public IFormFile File { get; set; }
	}
}
