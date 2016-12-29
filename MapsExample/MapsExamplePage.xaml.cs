using System;
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

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Position(-32, -56), Distance.FromKilometers(1))
			);

			positionLabel.Text = "alvaro";

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
				positionLabel.Text = senderEv + ": " + ev; 
				Debug.WriteLine(senderEv);
				Debug.WriteLine(ev);
			};

			var position = await locator.GetPositionAsync(10000);

			await DisplayAlert("Position Status: {0}", position.Timestamp.ToString(), "OK");
			await DisplayAlert("Position Latitude: {0}", position.Latitude.ToString(), "OK");
			await DisplayAlert("Position Longitude: {0}", position.Longitude.ToString(), "OK");
		}
	}
}
