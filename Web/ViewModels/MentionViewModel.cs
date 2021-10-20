using System;
using Web.Enums;

namespace Web.ViewModels
{
	public class MentionViewModel
	{
		public int ID { get; set; }
		public string UserID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public MentionCategory MentionCategory { get; set; }
		public string Image { get; set; }
		public int Likes { get; set; }
		public int Views { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime LastModified { get; set; }
		public bool Status { get; set; }
	}
}
