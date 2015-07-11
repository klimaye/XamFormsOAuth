using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using FormsOAuth.iOS;
using FormsOAuth;
using Xamarin.Auth;

[assembly: ExportRenderer(typeof(FacebookLogin), typeof(FacebookLoginPageRenderer))]
namespace FormsOAuth.iOS
{
	public class FacebookLoginPageRenderer : PageRenderer
	{
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (App.IsLoggedIn)
				return;

			var fbAuth = new OAuth2Authenticator (
				clientId: App.Constants.facebookClientId,
				scope: "public_profile,email",
				authorizeUrl:new Uri("https://facebook.com/dialog/oauth/"),
				redirectUrl:new Uri("http://www.facebook.com/connect/login_success.html")
			);

			fbAuth.Completed += (sender, e) => {
				DismissViewController(true, null);
				if (e.IsAuthenticated) {
					App.User = new TwitterUser();
					App.SuccessfulLoginAction.Invoke();
				}
			};
			PresentViewController (fbAuth.GetUI (), true, null);
		}
	}
}

