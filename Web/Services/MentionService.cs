using ApplicationCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
	public class MentionService : IMentionService
	{
		private readonly HttpClient _httpClient;

		public MentionService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task Create(CreateMentionViewModel mention)
		{
			var response = await _httpClient.PostAsJsonAsync("Mention/create", mention);
			//var content = new StringContent(JsonConvert.SerializeObject(mention), Encoding.UTF8, "application/json");
			//var response = await _httpClient.PostAsync("Mention/create", content);
			var result = response.Content.ReadAsStringAsync().Result;
			response.EnsureSuccessStatusCode();
		}

		public async Task<MentionViewModel> GetMentionById(int id)
		{
			var response = await _httpClient.GetAsync($"Mention/{id}");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<MentionViewModel>();
		}

		public async Task<IList<MentionViewModel>> GetMentionByUserId(int id)
		{
			var response = await _httpClient.GetAsync($"Mention/userMentions/{id}");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<MentionViewModel>>();
		}

		public async Task<IList<MentionViewModel>> GetMention()
		{
			var response = await _httpClient.GetAsync($"Mention");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<IList<MentionViewModel>>();
		}

		public async Task UpdateMention(MentionViewModel userToUpdate)
{
			var response = await _httpClient.PutAsJsonAsync($"Mention/{userToUpdate.ID}", userToUpdate);
			//var content = new StringContent(JsonConvert.SerializeObject(userToUpdate), Encoding.UTF8, "application/json");
			//var response = await _httpClient.PutAsync($"Mention/{userToUpdate.ID}", content);
			response.EnsureSuccessStatusCode();
		}

		public async Task Delete(int id)
		{
			var response = await _httpClient.DeleteAsync($"Mention/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
