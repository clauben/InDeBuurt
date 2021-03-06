using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Models
{
	public class AuthenticateModel
	{
		[Required]
		public string EmailAddress { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
