using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationCore.Entities
{
	public class UserDetail
	{
		public int ID { get; set; }
		public int UserID { get; set; }
		
		[Required]
		[StringLength(50, MinimumLength = 3)]
		[Display(Name = "Voornaam")]
		public string FirstName { get; set; }
		
		[Required]
		[StringLength(50, MinimumLength = 3)]
		[Display(Name = "Achternaam")]
		public string LastName { get; set; }
		
		[Required]
		[StringLength(100)]
		[Display(Name = "Land")]
		public string Country { get; set; }
		
		[Required]
		[StringLength(100)]
		[Display(Name = "Stad")]
		public string City { get; set; }
		
		[Required]
		[StringLength(100)]
		[Display(Name = "Straat")]
		public string Street { get; set; }
		
		[Display(Name = "Straatnummer")]
		public int StreetNumber { get; set; }

		[Display(Name = "Straatletter")]
		public char? StreetLetter { get; set; }
		
		[Required]
		[StringLength(10)]
		[Display(Name = "Postcode")]
		public string ZipCode { get; set; }
		
		[Required]
		[StringLength(15)]
		[Display(Name = "Telefoonnummer")]
		public string PhoneNumber { get; set; }
	}
}
