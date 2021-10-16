using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Interfaces
{
	public interface IMentionService
	{
		Task Create(CreateMentionViewModel mention);
		Task Delete(int id);
		Task<MentionViewModel> GetMentionById(int id);
		Task<IList<MentionViewModel>> GetMentionByUserId(int id);
		Task<IList<MentionViewModel>> GetMention();
		Task UpdateMention(MentionViewModel userToUpdate);
	}
}