using System.Threading.Tasks;
using Web.Areas.Auth.ViewModels;

namespace Web.Interfaces
{
	public interface IUserApiAuthService
	{
		Task<string> RetrieveToken(LoginViewModel userAuth);
	}
}