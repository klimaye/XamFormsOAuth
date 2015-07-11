using System;

using Xamarin.Forms;

namespace FormsOAuth
{
	public class App : Application
	{
		static NavigationPage _NavPage;
		public static TwitterUser User;


		public static class Constants
		{
			public const string consumerKey= "Twitter consumer key";
			public const string consumerSecret= "Twitter consumer secret key";
			public const string facebookClientId = "Facebook app id";
			public static Uri requestTokenUrl() {
				return new Uri ("https://api.twitter.com/oauth/request_token");
			}
			public static Uri authorizeUrl() {
				return new Uri("https://api.twitter.com/oauth/authorize");
			}
			public static Uri accessTokenUrl() {
				return new Uri("https://api.twitter.com/oauth/access_token");				
			}
			public static Uri callbackUrl() {
				return new Uri("http://www.praeses.com");
			}
		}

		public static Page GetMainPage()
		{
			//var profilePage = new ProfilePage ();
			var appStartPage = new AppStartPage();
			_NavPage = new NavigationPage (appStartPage);
			return _NavPage;			
		}
			
		public static bool IsLoggedIn {
			get { return !(User == null); }
		}
		public static Action SuccessfulLoginAction
		{
			get {
				return new Action (async () => {
					await _NavPage.Navigation.PopModalAsync();
					await _NavPage.Navigation.PushModalAsync(new ProfilePage());
				});
			}
		}

		public App ()
		{
			MainPage = GetMainPage ();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

