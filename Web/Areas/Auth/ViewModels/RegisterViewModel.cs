using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Web.Areas.Auth.ViewModels
{
	public class RegisterViewModel
	{
		[DataType(DataType.Text)]
		[Display(Name = "Voornaam")]
		public string FirstName { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Achternaam")]
		public string LastName { get; set; }

		[DataType(DataType.EmailAddress)]
		[Display(Name = "Emailadres")]
		public string EmailAddress { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Wachtwoord")]
		public string Password { get; set; }
	}
}
