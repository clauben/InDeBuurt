using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Infrastruture.Data;

namespace Web.Pages.Mentions
{
    public class EditModel : PageModel
    {
        private readonly Infrastruture.Data.WebContext _context;

        public EditModel(Infrastruture.Data.WebContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mention).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentionExists(Mention.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MentionExists(int id)
        {
            return _context.Mentions.Any(e => e.ID == id);
        }
    }
}
