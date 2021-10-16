using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Auth.Pages.Login;
using Web.Areas.Auth.ViewModels;
using Web.Interfaces;
using Web.Services;
using Web.ViewModels;

namespace Web.Pages.UserProfile
{
    public class UserProfileModel : PageModel
    {
		private readonly HttpClient _client;
		private readonly IUserService _userService;

		[BindProperty]
		public ProfileViewModel ProfileViewModel { get; set; }

		public UserProfileModel(HttpClient client, IUserService userService)
		{
			_client = client;
			_userService = userService;
		}

		public async Task OnGetAsync()
        {
			int id = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
			ProfileViewModel = await _userService.GetUser(id);
		}

		public async Task<IActionResult> OnPostSaveAsync()
		{
			await _userService.UpdateUser(ProfileViewModel);
			return RedirectToPage("/IndexFeed");
		}

		public async Task OnPostDeleteAsync()
		{
			int id = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
			await _userService.DeleteUser(id);
		}
	}
}
