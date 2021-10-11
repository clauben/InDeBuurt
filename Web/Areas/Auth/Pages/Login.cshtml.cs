using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Web.Areas.Auth.ViewModels;
using Web.Interfaces;
using Web.Services;

namespace Web.Areas.Auth.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient _client;
		private readonly IMemoryCache _memoryCache;
		private IUserApiAuthService _authService;

		[BindProperty]
		public LoginViewModel UserAuth { get; set; }

        [BindProperty]
        public RegisterViewModel UserRegister { get; set; }

		public AuthResponse AuthResponse { get; set; }

		public LoginModel(HttpClient client, IMemoryCache memoryCache, IUserApiAuthService authService)
		{
            _client = client;
			_memoryCache = memoryCache;
			_authService = authService;
		}

		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAuth()
		{
            var token = await _authService.RetrieveToken(UserAuth);

            //var client = _client.CreateClient("MyClient");
            //HttpResponseMessage response = await client.PostAsJsonAsync("User/authenticate", UserAuth);
            //var authResponse = await response.Content.ReadAsAsync<AuthResponse>();
            //var userinfo = JsonConvert.DeserializeObject<AuthResponse>(jasonString);


            if (!ModelState.IsValid)
			{
                return Page();
            }

            if (!String.IsNullOrEmpty(token))
            {
                return RedirectToPage("/IndexFeed");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRegister()
		{
            HttpResponseMessage response = await _client.PostAsJsonAsync("User/register", UserRegister);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (response.IsSuccessStatusCode)
            {     
                return Page();
            }

            return Page();
        }
    }
}
