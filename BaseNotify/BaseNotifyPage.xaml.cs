using Xamarin.Forms;
using BaseNotify.ViewModels;
using BaseNotify.Services;
using BaseNotify.Models;

namespace BaseNotify
{
	public partial class BaseNotifyPage : ContentPage
	{
		public BaseNotifyPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel(new Service());
		}

		private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var tag = (sender as ListView)?.SelectedItem as Tag;
			(BindingContext as MainViewModel)?.ShowCategoriaCommand.Execute(tag);
		}
	}
}
