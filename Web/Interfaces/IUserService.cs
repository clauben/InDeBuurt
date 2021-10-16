using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Areas.Auth.ViewModels;
using Web.ViewModels;

namespace Web.Interfaces
{
	public interface IUserService
	{
		Task<ProfileViewModel> GetUser(int id);
		Task UpdateUser(ProfileViewModel userToUpdate);
		Task DeleteUser(int id);
		Task<HttpResponseMessage> CreateUser(RegisterViewModel createUser);
	}
}