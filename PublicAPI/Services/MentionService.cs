using ApplicationCore.Entities;
using Infrastruture.Data;
using PublicAPI.Helpers;
using PublicAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PublicAPI.Services
{
	public class MentionService : IMentionService
	{
		private readonly WebContext _context;

		public MentionService(WebContext context)
		{
			_context = context;
		}

		public IEnumerable<Mention> GetAll()
		{
			return _context.Mentions;
		}

		public IEnumerable<Mention> GetAllByUserId(int id)
		{
			var mentions = _context.Mentions
				.Where(m => m.UserID == id).ToList();
			return mentions;
		}

		public Mention GetById(int id)
		{
			return _context.Mentions.Find(id);
		}

		public Mention Create(Mention mention)
		{
			if (string.IsNullOrWhiteSpace(mention.Title))
				throw new AppException("Title is required");

			if (string.IsNullOrWhiteSpace(mention.Description))
				throw new AppException("Description is required");

			_context.Mentions.Add(mention);
			_context.SaveChanges();

			return mention;
		}

		public void Update(Mention mentionParam)
		{
			var mention = _context.Mentions.Find(mentionParam.ID);

			if (!string.IsNullOrWhiteSpace(mentionParam.Title))
			{
				mention.Title = mentionParam.Title;
			}

			if (!string.IsNullOrWhiteSpace(mentionParam.Description))
			{
				mention.Description = mentionParam.Description;
			}

			if (!mentionParam.MentionCategory.Equals(mention.MentionCategory))
			{
				mention.Title = mentionParam.Title;
			}

			_context.Mentions.Update(mention);
			_context.SaveChanges();

		}

		public void Delete(int id)
		{
			var mention = _context.Mentions.Find(id);
			if (mention != null)
			{
				_context.Mentions.Remove(mention);
				_context.SaveChanges();
			}
		}
	}
}
