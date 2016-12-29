using System;
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
	}
}
