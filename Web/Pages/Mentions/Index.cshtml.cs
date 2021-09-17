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
    public class IndexModel : PageModel
    {
        private readonly Infrastruture.Data.WebContext _context;

        public IndexModel(Infrastruture.Data.WebContext context)
        {
            _context = context;
        }

        public IList<Mention> Mention { get;set; }

        public async Task OnGetAsync()
        {
            Mention = await _context.Mentions.ToListAsync();
        }
    }
}
