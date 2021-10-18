using ApplicationCore.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Pages
{
	[Authorize]
	public class IndexModel : PageModel
	{
		private readonly HttpClient _httpClient;
		private readonly IMentionService _mention;

		public IndexModel(HttpClient httpClient, IMentionService mention)
        {
			_httpClient = httpClient;
			_mention = mention;
		}

        public List<MentionViewModel> Mention = new List<MentionViewModel>();

		[BindProperty]
		public CreateMentionViewModel Update { get; set; } = new CreateMentionViewModel();

		public async Task OnGetAsync()
        {
			//Mention = await _context.Mentions.ToListAsync();
			var mentions = await _mention.GetMention();

			foreach(MentionViewModel m in mentions)
			{
				Mention.Add(m);
			}
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _mention.Create(Update);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}
