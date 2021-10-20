using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Web.Enums;

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
