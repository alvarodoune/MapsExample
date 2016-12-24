using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapsExample
{
	public partial class MapsExamplePage : ContentPage
	{
		public MapsExamplePage()
		{
			InitializeComponent();

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Position(37, -122), Distance.FromKilometers(5))
			);

			var pin = new Pin
			{
				Position = new Position(-32.3145667, -58.0925143),
				Address = "Adress 1",
				Label = "Label 1"
			};

			pin.Clicked += (sender, e) =>
			{
				var selectedPin = sender as Pin;
				DisplayAlert(selectedPin.Label, selectedPin.Address, "OK");
			};

			MyMap.Pins.Add(pin);
		}
	}
}
