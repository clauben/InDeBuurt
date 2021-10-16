using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationCore.Entities
{
	public class Comment
	{
		public int ID { get; set; }
		public int? UserID { get; set; }
		public int MentionID { get; set; }

		[Required]
		[StringLength(4000)]
		[Display(Name = "Beschrijving")]
		public string Description { get; set; }

		public int Likes { get; set; }

		public DateTime CreateDate { get; set; }
		public DateTime LastModified { get; set; }
	}
}
