using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Pages.Mentions
{
	[Authorize]
	public class EditModel : PageModel
	{
		private readonly IMentionService _mention;

		public EditModel(IMentionService mention)
		{
			_mention = mention;
		}

		[BindProperty]
		public UpdateMentionViewModel UpdateMention { get; set; }

		[BindProperty]
		public MentionViewModel Mention { get; set; } = new MentionViewModel();


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

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			await _mention.UpdateMention(Mention);


			return RedirectToPage("./Index");
		}
	}
}
