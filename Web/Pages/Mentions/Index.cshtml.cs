using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Infrastruture.Data;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Pages.Mentions
{
    [BindProperties]
    public class IndexModel : PageModel
    {
		private readonly IMentionService _mention;

		public IndexModel(IMentionService mention)
        {
			_mention = mention;
		}

        public IList<MentionViewModel> Mention { get; set; }

        public async Task OnGetAsync()
        {
            int id = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserID").Value);
            Mention = await _mention.GetMentionByUserId(id);
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            await _mention.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
