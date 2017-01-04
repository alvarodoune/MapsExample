using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MapsExample
{
	public partial class ViewReportModalPage : ContentPage
	{
		public ViewReportModalPage(Report report)
		{
			InitializeComponent();
			nameLabel.Text = report.Name;
		}

		void BackButton_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PopModalAsync();
		}
	}
}
