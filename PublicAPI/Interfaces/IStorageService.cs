using Microsoft.AspNetCore.Http;

namespace PublicAPI.Interfaces
{
	public interface IStorageService
	{
		void Upload(IFormFile formFile);
	}
}