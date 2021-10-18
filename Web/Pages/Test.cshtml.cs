using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Pages
{
    public class TestModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IMentionService _mention;

        public TestModel(HttpClient httpClient, IMentionService mention)
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

            foreach (MentionViewModel m in mentions)
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