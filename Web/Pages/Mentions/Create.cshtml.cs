using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ApplicationCore.Entities;
using Infrastruture.Data;

namespace Web.Pages.Mentions
{
    public class CreateModel : PageModel
    {
        private readonly Infrastruture.Data.WebContext _context;

        public CreateModel(Infrastruture.Data.WebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mention Mention { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mentions.Add(Mention);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
