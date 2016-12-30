using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapsExample
{
	public partial class MapsExamplePage : TabbedPage
	{
		public MapsExamplePage()
		{
			InitializeComponent();

			listView.ItemsSource = new List<Report> { 
				new Report { Name="Reporte1", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/1" },
				new Report { Name="Reporte2", Status="lost", ImageUrl="http://lorempixel.com/100/100/animals/2" }
			};

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Position(-32, -56), Distance.FromKilometers(1))
			);

			//positionLabel.Text = "alvaro";

			var pin = new Pin
			{
				Position = new Position(-32.3145667, -58.0925143),
				Address = "Adress 1",
				Label = "The Label"
			};

			var pin2 = new Pin
			{
				Position = new Position(-32.4545677, -56.2026182),
				Address = "Adress 2",
				Label = "The Label 2"
			};

			pin.Clicked += (sender, e) =>
			{
				var selectedPin = sender as Pin;
				DisplayAlert(selectedPin.Label, selectedPin.Address, "OK");
			};

			pin2.Clicked += (sender, e) =>
			{
				var selectedPin = sender as Pin;
				DisplayAlert(selectedPin.Label, selectedPin.Address, "OK");
			};

			MyMap.Pins.Add(pin);
			MyMap.Pins.Add(pin2);
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			locator.PositionChanged += (senderEv, ev) => 
			{
				//positionLabel.Text = senderEv + ": " + ev; 
				System.Diagnostics.Debug.WriteLine(senderEv);
				System.Diagnostics.Debug.WriteLine(ev);
			};

			var position = await locator.GetPositionAsync(10000);

			await DisplayAlert("Position Status: {0}", position.Timestamp.ToString(), "OK");
			await DisplayAlert("Position Latitude: {0}", position.Latitude.ToString(), "OK");
			await DisplayAlert("Position Longitude: {0}", position.Longitude.ToString(), "OK");
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}
			DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
			//((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
		}
	}
}
