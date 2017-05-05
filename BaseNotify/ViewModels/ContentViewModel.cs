using BaseNotify.Models;

namespace BaseNotify.ViewModels
{
	public class ContentViewModel: BaseViewModel
	{
		public Content Content {get;} 

		public ContentViewModel(Content content)
		{
			Content = content;
		}
	}
}