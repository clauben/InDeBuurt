using ApplicationCore.Entities;
using System.Collections.Generic;

namespace PublicAPI.Interfaces
{
	public interface IMentionService
	{
		Mention Create(Mention mention);
		void Delete(int id);
		IEnumerable<Mention> GetAll();
		IEnumerable<Mention> GetAllByUserId(int id);
		Mention GetById(int id);
		void Update(Mention mentionParam);
	}
}