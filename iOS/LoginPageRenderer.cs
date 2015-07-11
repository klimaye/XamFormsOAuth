using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using FormsOAuth;
using FormsOAuth.iOS;
using Xamarin.Auth;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace FormsOAuth.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

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
			auth.BrowsingCompleted += (sender, e) => {
				Console.WriteLine("browsing completed");
			};
			auth.Error += (sender, e) => {
				Console.WriteLine("There was an error {0}",e.Message);
			};				
			auth.Completed += (sender, e) => {
				Console.WriteLine ("Inside completed");
				DismissViewController(true, null);
				
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
			PresentViewController (auth.GetUI (), true, null);
		}			
	}
}

