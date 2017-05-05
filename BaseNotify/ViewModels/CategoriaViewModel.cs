

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using BaseNotify.Models;
using BaseNotify.Services;
using Xamarin.Forms;

namespace BaseNotify.ViewModels
{
	public class CategoriaViewModel:BaseViewModel
	{

		private readonly IService _service;
		private readonly Tag _tag;

		public ObservableCollection<Content> Contents { get;}
		public Command<Content> ShowContentCommand { get; }

		public CategoriaViewModel(IService service, Tag tag)
		{
			_service = service;
			_tag = tag;

			Contents = new ObservableCollection<Content>();
			ShowContentCommand = new Command<Content>(ExecuteShowContentCommand);
			
		}

		private async void ExecuteShowContentCommand(Content content)
		{
			await PushAsync<ContentViewModel>(content);
		}

		//Método para popular a ObservableCollection no override do evento OnAppearing da página de categoria.
		public async Task LoadAsync()
		{
			var contents = await _service.GetContentsByTagIdAsync(_tag.Id);

			Contents.Clear();

			foreach (var item in contents)
			{
				Contents.Add(item);
			}
		}
	}
}
