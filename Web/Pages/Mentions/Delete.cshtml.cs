using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Pages.Mentions
{
	[Authorize]
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
