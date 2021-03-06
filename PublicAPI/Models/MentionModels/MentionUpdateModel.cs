using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Models.MentionModels
{
	public class MentionUpdateModel
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public MentionCategory MentionCategory { get; set; }
		public string Image { get; set; }
		public DateTime LastModified { get; set; }
	}
}
