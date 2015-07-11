using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsOAuth;
using FormsOAuth.Droid;
using Android.App;
using Xamarin.Auth;

[assembly: ExportRenderer (typeof (LoginPage), typeof (LoginPageRenderer))]
namespace FormsOAuth.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		
		protected override void OnElementChanged (ElementChangedEventArgs<Page> eventArgs)
		{
			base.OnElementChanged (eventArgs);
			var activity = this.Context as Activity;
			if (App.IsLoggedIn)
				return;

			var auth = new OAuth1Authenticator(
				consumerKey: App.Constants.consumerKey,
				consumerSecret: App.Constants.consumerSecret,
				requestTokenUrl: App.Constants.requestTokenUrl(), 
				authorizeUrl: App.Constants.authorizeUrl(), 
				accessTokenUrl: App.Constants.accessTokenUrl(),
				callbackUrl: App.Constants.callbackUrl()
			);
			auth.Title = "Login with Twitter";
			auth.BrowsingCompleted += (s, e) => {
				Console.WriteLine("browsing completed");
			};
			auth.Error += (s, e) => {
				Console.WriteLine("There was an error {0}",e.Message);
			};				
			auth.Completed += (s, e) => {
				Console.WriteLine ("Inside completed");
				if (e.IsAuthenticated) {
					App.User = new TwitterUser();
					var properties = e.Account.Properties;
					App.User.Token = e.Account.Properties["oauth_token"];
					App.User.TokenSecret = e.Account.Properties["oauth_token_secret"];
					App.User.TwitterId = e.Account.Properties["user_id"];
					App.User.Name = e.Account.Properties["screen_name"];

					App.SuccessfulLoginAction.Invoke();
				}
			};
			activity.StartActivity(auth.GetUI(activity));
		}
	}
}

