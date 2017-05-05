using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using BaseNotify.Models;
using System.Collections.ObjectModel;
using System;
using BaseNotify.Services;

namespace BaseNotify.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private string _searchTerm;

		public string SearchTerm
		{
			get { return _searchTerm; }
			set
			{
				if (SetProperty(ref _searchTerm, value))
					SearchCommand.ChangeCanExecute();
			}
		}

		public ObservableCollection<Tag> Resultados { get; }
		public Command SearchCommand { get; }
		public Command AboutCommand { get; }
		public Command<Tag> ShowCategoriaCommand { get; }

		private readonly IService _service;

		public MainViewModel(IService service) 
		{
			_service = service;
			SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
			AboutCommand = new Command(ExecuteAboutCommand);
			ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);
			Resultados = new ObservableCollection<Tag>();
		}

		async void ExecuteAboutCommand()
		{
			
		}

		async void ExecuteSearchCommand()
		{
			var tagsRetornadasDoServico = await _service.GetTagsAsync();

			if (tagsRetornadasDoServico != null)
			{
				foreach (var tag in tagsRetornadasDoServico)
				{
					Resultados.Add(tag);
				}
			}
		}

		private async void ExecuteShowCategoriaCommand(Tag tag)
		{
			await PushAsync<CategoriaViewModel>(_service, tag);
		}

		bool CanExecuteSearchCommand()
		{
			return !string.IsNullOrWhiteSpace(SearchTerm);
		}
	}
}
