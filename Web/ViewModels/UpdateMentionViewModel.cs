using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
	public class UpdateMentionViewModel
	{
		public int UserID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public MentionCategory MentionCategory { get; set; }
		public string Image { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
