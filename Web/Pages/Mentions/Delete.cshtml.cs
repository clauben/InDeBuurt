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
    public class DeleteModel : PageModel
    {
		private readonly IMentionService _mention;

		public DeleteModel(IMentionService mention)
        {
			_mention = mention;
		}

        [BindProperty]
        public MentionViewModel Mention { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        { 
            if (id == null)
            {
                return NotFound();
            }

            Mention = await _mention.GetMentionById(id);

            if (Mention == null)
            {
                return NotFound();
            }
        return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            await _mention.Delete(id);

            return RedirectToPage("./Index");
        }
    }
}
