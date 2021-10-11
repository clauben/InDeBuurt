using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationCore.Entities
{
	public enum UserStatus
	{
		Pending, Active, Blocked, Retired
	}

	public enum UserRole
	{
		Resident, Administrator, Moderator
	}

	public class User
	{
		public int ID { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[Display(Name = "Voornaam")]
		public string FirstName { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 3)]
		[Display(Name = "Achternaam")]
		public string LastName { get; set; }

		[Required]
		[StringLength(200)]
		[Display(Name = "Email")]
		public string EmailAddress { get; set; }

		[StringLength(15)]
		[Display(Name = "Telefoonnummer")]
		public string PhoneNumber { get; set; }

		[Required]
		[Display(Name = "Account status")]
		public UserStatus UserStatus { get; set; } = UserStatus.Pending;

		[Required]
		[Display(Name = "Account role")]
		public UserRole UserRole { get; set; } = UserRole.Resident;

		[Required]
		public byte[] PasswordSalt { get; set; }

		[Required]
		public byte[] PasswordHash { get; set; }

		public ICollection<Mention> Mentions { get; set; }
		public ICollection<Comment> Comments { get; set; }
	}
}
