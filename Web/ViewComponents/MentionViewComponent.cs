using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;

namespace Web.ViewComponents
{
	public class MentionViewComponent : ViewComponent
	{
		private readonly IUserService _userService;
		public MentionViewComponent Mention { get; set; }

		public MentionViewComponent(IUserService userService)
		{
			_userService = userService;
		}

		public IViewComponentResult Invoke()
		{
			return View(Mention);
		}
	}
}
