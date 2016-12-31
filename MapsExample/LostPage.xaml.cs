using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MapsExample
{
	public partial class LostPage : ContentPage
	{
		public LostPage()
		{
			InitializeComponent();

			listView.ItemsSource = new List<Report> {
				new Report { Name="Reporte1", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/1" },
				new Report { Name="Reporte2", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/2" },
				new Report { Name="Reporte3", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/3" },
				new Report { Name="Reporte4", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/4" },
				new Report { Name="Reporte5", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/5" }
			};
		}

		void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			//DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
			((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
			this.NavigateToLost(sender, e);
		}

		async void NavigateToLost(Object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage());
		}
	}
}
