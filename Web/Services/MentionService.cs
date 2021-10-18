using ApplicationCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
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
			var fileContent = new StreamContent(mention.File.OpenReadStream())
			{
				Headers =
				{
					ContentLength = mention.File.Length,
					ContentType = new MediaTypeHeaderValue(mention.File.ContentType)
				}
			};

			var formDataContent = new MultipartFormDataContent();
			formDataContent.Add(fileContent, "File", mention.File.FileName);          
			formDataContent.Add(new StringContent(mention.UserID.ToString()), "UserID");
			formDataContent.Add(new StringContent(mention.Title.ToString()), "Title");
			formDataContent.Add(new StringContent(mention.Description.ToString()), "Description");
			formDataContent.Add(new StringContent(mention.MentionCategory.ToString()), "MentionCategory");
			formDataContent.Add(new StringContent("https://idbopslag.blob.core.windows.net/idb/" + mention.File.FileName), "Image");

			await _httpClient.PostAsync("Mention/create", formDataContent);

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
			response.EnsureSuccessStatusCode();
		}

		public async Task Delete(int id)
		{
			var response = await _httpClient.DeleteAsync($"Mention/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
