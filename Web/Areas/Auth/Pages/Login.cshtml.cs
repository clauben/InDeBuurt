using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
		private readonly IUserService _userService;

		[BindProperty]
		public LoginViewModel UserAuth { get; set; }

        [BindProperty]
        public RegisterViewModel UserRegister { get; set; } = new RegisterViewModel();

		public AuthResponse AuthResponse { get; set; }

		public LoginModel(HttpClient client, IMemoryCache memoryCache, IUserApiAuthService authService, IUserService userService)
		{
            _client = client;
			_memoryCache = memoryCache;
			_authService = authService;
			_userService = userService;
		}

		public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAuth()
		{
            var response = await _authService.RetrieveToken(UserAuth);

            if (!ModelState.IsValid)
			{
                return Page();
            }

            if (response.Item1.IsSuccessStatusCode)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, response.Item2),
                    new Claim("UserID", response.Item3),
                    new Claim("Token", response.Item4),
                    new Claim("TokenExpiration", response.Item5.ToString("s"))
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                { };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToPage("/IndexFeed");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRegister()
		{
            var response = await _userService.CreateUser(UserRegister);

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
