using System;
using System.Collections.Generic;
using BaseNotify.ViewModels;
using Xamarin.Forms;

namespace BaseNotify
{
	public partial class Categoria : ContentPage
	{
		public Categoria()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			(BindingContext as CategoriaViewModel)?.LoadAsync();
			base.OnAppearing();
		}

		private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e) 
		{
			var content = (sender as ListView)?.SelectedItem;
			(BindingContext as CategoriaViewModel)?.ShowContentCommand.Execute(content);
		}
	}
}
