using System;

namespace FormsOAuth
{
	public class TwitterUser
	{
		public string TwitterId { get; set; }
		public string Name { get; set; }
		public string ScreenName { get; set; }
		public string Token { get; set; }
		public string TokenSecret { get; set; }
		public bool IsAuthenticated
		{
			get { return !string.IsNullOrWhiteSpace (Token); }
		}
	}
}
