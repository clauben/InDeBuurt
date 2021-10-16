using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Auth.ViewModels
{
	public class AuthResponse
	{
		public string Token { get; set; }
		public string FirstName { get; set; }
		public string ID { get; set; }
		public DateTime Expiration { get; set; }

		public void Deconstruct(out string token, out string firstName, out string id,  out DateTime expirationDate)
		{
			token = Token;
			firstName = FirstName;
			id = ID;
			expirationDate = Expiration;
		}
	}
}
