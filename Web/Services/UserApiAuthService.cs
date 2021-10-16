using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Areas.Auth.ViewModels;
using Web.Interfaces;

namespace Web.Services
{
	public class UserApiAuthService : IUserApiAuthService
	{
		private readonly HttpClient _httpClient;

		public UserApiAuthService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<Tuple<HttpResponseMessage, string, string, string, DateTime>> RetrieveToken(LoginViewModel userAuth)
		{
			DateTime expirationDate;
			string firstName;
			string id;
			string token;

			HttpResponseMessage response = await _httpClient.PostAsJsonAsync("User/authenticate", userAuth);
			(token, firstName, id, expirationDate) = await response.Content.ReadAsAsync<AuthResponse>();
			return Tuple.Create(response, firstName, id, token, expirationDate);
		}
	}
}
