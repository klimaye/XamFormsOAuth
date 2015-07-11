using System;

using Xamarin.Forms;

namespace FormsOAuth
{
	public class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			Content = new Label () {
				Text = "Profile Page",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
		}
	}

}

