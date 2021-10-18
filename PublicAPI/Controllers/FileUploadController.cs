using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicAPI.Controllers
{
	//[ApiController]
	//[Route("[controller]")]
	//public class FileUploadController : ControllerBase
	//{
	//	private readonly IStorageService _storageService;

	//	public FileUploadController(IStorageService storageService)
	//	{
	//		_storageService = storageService;
	//	}

	//	[HttpGet]
	//	public IActionResult Get()
	//	{
	//		return Ok();
	//	}

	//	[HttpPost]
	//	[Route("upload")]
	//	public IActionResult Upload(IFormFile file)
	//	{
	//		_storageService.Upload(file);
	//		return Ok();
	//	}
	//}
}
