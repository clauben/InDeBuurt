using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Models
{
	public class UserModel
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string PhoneNumber { get; set; }
		public UserStatus UserStatus { get; set; }
		public UserRole UserRole { get; set; }
	}
}
