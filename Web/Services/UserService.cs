using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Areas.Auth.ViewModels;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
	public class UserService : IUserService
	{
		private readonly HttpClient _httpClient;

		public UserService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ProfileViewModel> GetUser(int id)
		{
			var response = await _httpClient.GetAsync($"User/{id}");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<ProfileViewModel>();
		}

		public async Task UpdateUser(ProfileViewModel userToUpdate)
		{
			var content = new StringContent(JsonConvert.SerializeObject(userToUpdate), Encoding.UTF8, "application/json");
			var response = await _httpClient.PutAsync($"user/{userToUpdate.ID}", content);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteUser(int id)
		{
			var response = await _httpClient.DeleteAsync($"User/{id}");
			response.EnsureSuccessStatusCode();
		}

		public async Task<HttpResponseMessage> CreateUser(RegisterViewModel createUser)
		{
			var response = await _httpClient.PostAsJsonAsync("User/register", createUser);
			response.EnsureSuccessStatusCode();
			return response;
		}
	}
}
