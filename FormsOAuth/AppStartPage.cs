using System;
using Xamarin.Forms;

namespace FormsOAuth
{
	public class AppStartPage : ContentPage
	{
		public AppStartPage ()
		{
			Content = new Label () {
				Text = "App Start Page",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (!App.IsLoggedIn) {
				Navigation.PushModalAsync (new LoginPage (), true);
			}
		}			
	}
}

