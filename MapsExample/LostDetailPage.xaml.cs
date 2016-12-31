using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MapsExample
{
	public partial class LostDetailPage : ContentPage
	{
		public LostDetailPage(Report report)
		{
			InitializeComponent();
			nameLabel.Text = report.Name;
		}
	}
}
