using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Infrastruture.Data;
using System.Net.Http;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Pages.Mentions
{
    public class DetailsModel : PageModel
    {
		private readonly IMentionService _mention;

		public DetailsModel(IMentionService mention)
        {
			_mention = mention;
		}

        public MentionViewModel Mention { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Mention = await _context.Mentions.FirstOrDefaultAsync(m => m.ID == id);

            Mention = await _mention.GetMentionById(id);

            if (Mention == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
