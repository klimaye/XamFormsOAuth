using System;
using Xamarin.Forms;

namespace FormsOAuth
{
	public class AppStartPage : ContentPage
	{
		public AppStartPage ()
		{
			Title = "Login";

			var faceBookButton = new Button () {				
				Text = "Facebook",
			};
			faceBookButton.Clicked += FaceBookButton_Clicked;
			var twitterButton = new Button () {
				Text = "Twitter"
			};
			twitterButton.Clicked += TwitterButton_Clicked;
			Content = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Children = {
					faceBookButton,
					twitterButton
				}
			};
		}

		void TwitterButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushModalAsync (new LoginPage (), true);
		}

		void FaceBookButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushModalAsync (new FacebookLogin (), true);
		}
	}
}

