using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
	public interface IUserService
	{
		Task<ProfileViewModel> GetUser(int id);
		Task UpdateUser(ProfileViewModel userToUpdate);
	}
}