using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Pages
{
	public class IndexFeedModel : PageModel
	{
        private readonly Infrastruture.Data.WebContext _context;

        public IndexFeedModel(Infrastruture.Data.WebContext context)
        {
            _context = context;
        }

        public IList<Mention> Mention { get; set; }

        public async Task OnGetAsync()
        {
            Mention = await _context.Mentions.ToListAsync();
        }
    }
}
