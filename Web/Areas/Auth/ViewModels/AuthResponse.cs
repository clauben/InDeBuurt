using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Auth.ViewModels
{
	public class AuthResponse
	{
		public string Token { get; set; }
		public DateTime Expiration { get; set; }

		public void Deconstruct(out string token, out DateTime expirationDate)
		{
			token = Token;
			expirationDate = Expiration;
		}
	}
}
