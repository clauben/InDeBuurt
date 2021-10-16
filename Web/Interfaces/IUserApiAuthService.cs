using System;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Areas.Auth.ViewModels;

namespace Web.Interfaces
{
	public interface IUserApiAuthService
	{
		Task<Tuple<HttpResponseMessage, string, string, string, DateTime>> RetrieveToken(LoginViewModel userAuth);
	}
}