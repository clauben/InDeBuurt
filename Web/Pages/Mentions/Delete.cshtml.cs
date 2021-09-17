using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Infrastruture.Data;

namespace Web.Pages.Mentions
{
    public class DeleteModel : PageModel
    {
        private readonly Infrastruture.Data.WebContext _context;

        public DeleteModel(Infrastruture.Data.WebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mention Mention { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mention = await _context.Mentions.FirstOrDefaultAsync(m => m.ID == id);

            if (Mention == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mention = await _context.Mentions.FindAsync(id);

            if (Mention != null)
            {
                _context.Mentions.Remove(Mention);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
