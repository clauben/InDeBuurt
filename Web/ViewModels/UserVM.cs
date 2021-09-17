using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
	public enum UserStatus
	{
		Pending, Active, Blocked, Retired
	}
	public class UserVM
	{
		public string EmailAddress { get; set; }
		public string UserName { get; set; }
	}
}
