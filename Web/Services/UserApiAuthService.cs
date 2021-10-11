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
		private readonly IMemoryCache _memoryCache;

		public UserApiAuthService(HttpClient httpClient, IMemoryCache memoryCache)
		{
			_httpClient = httpClient;
			_memoryCache = memoryCache;
		}

		public async Task<string> RetrieveToken(LoginViewModel userAuth)
		{
			DateTime expirationDate;
			if (!_memoryCache.TryGetValue("Token", out string token))
			{
				HttpResponseMessage response = await _httpClient.PostAsJsonAsync("User/authenticate", userAuth);
				(token, expirationDate) = await response.Content.ReadAsAsync<AuthResponse>();
				_memoryCache.Set("Token", token, new DateTimeOffset(expirationDate));
			}
			return token;
		}
	}
}
