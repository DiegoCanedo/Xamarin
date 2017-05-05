using System.Collections.Generic;
using System.Threading.Tasks;
using BaseNotify.Models;

namespace BaseNotify.Services
{
	public interface IService
	{
		Task<List<Tag>> GetTagsAsync();
		Task<List<Content>> GetContentsByTagIdAsync(string tagId);
		Task<List<Content>> GetContentsByFilterAsync(string filter);
	}
}
