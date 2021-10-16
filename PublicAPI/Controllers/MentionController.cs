using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PublicAPI.Helpers;
using PublicAPI.Interfaces;
using PublicAPI.Models.MentionModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PublicAPI.Controllers
{
	[Authorize]
	[ApiController]
	[Route("[controller]")]
	public class MentionController : ControllerBase
	{
		private IMentionService _mentionService;
		private IMapper _mapper;
		private readonly IOptions<AppSettings> _appSettings;

		public MentionController(
			IMentionService mentionService, 
			IMapper mapper, 
			IOptions<AppSettings> appSettings)
		{
			_mentionService = mentionService;
			_mapper = mapper;
			_appSettings = appSettings;
		}

		[HttpPost("create")]
		public IActionResult Create([FromBody] MentionCreateModel model)
		{
			var mention = _mapper.Map<Mention>(model);
			mention.CreateDate = DateTime.UtcNow;

			try
			{
				_mentionService.Create(mention);
				return Ok();
			}
			catch (WebException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			var mention = _mentionService.GetAll();
			var model = _mapper.Map<IList<MentionModel>>(mention);
			return Ok(model);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var mention = _mentionService.GetById(id);
			var model = _mapper.Map<MentionModel>(mention);
			return Ok(model);
		}

		[HttpGet("userMentions/{id}")]
		public IActionResult GetAllByUserId(int id)
		{
			var mention = _mentionService.GetAllByUserId(id);
			var model = _mapper.Map<IList<MentionModel>>(mention);
			return Ok(model);
		}

		[HttpPut("{id}")]
		public IActionResult update(int id, [FromBody] MentionUpdateModel model)
		{
			var mention = _mapper.Map<Mention>(model);
			mention.ID = id;
			mention.LastModified = DateTime.UtcNow;

			try
			{
				_mentionService.Update(mention);
				return Ok();
			}
			catch (AppException ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_mentionService.Delete(id);
			return Ok();
		}
	}
}
