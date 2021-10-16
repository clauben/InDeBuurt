using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
	public enum MentionCategory
	{
		Announcement,
		Information,
		Question,
		Crime,
		Suggestion
	}
	public class Mention
	{
		public int ID { get; set; }

		public int? UserID { get; set; }

		[Required]
		[StringLength(200)]
		[Display(Name = "Titel")]
		public string Title { get; set; }

		[Required]
		[StringLength(4000)]
		[Display(Name = "Beschrijving")]
		public string Description { get; set; }

		[Required]
		[Display(Name = "Category")]
		public MentionCategory MentionCategory { get; set; }

		public string Image { get; set; }
		public int Likes { get; set; } = 0;
		public int Views { get; set; } = 0;

		[DataType(DataType.Date)]
		public DateTime CreateDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime LastModified { get; set; }
		public bool Status { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}
