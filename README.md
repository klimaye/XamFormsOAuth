# Demo Social Media authentication via Xamarin.Auth
## Twitter
The twitter oauth1 integration was tricky. There were a few samples on the web but they were missing a detail here and there that did not lead to a complete cross platform solution as of 7/11/2015.
### Gotchas
 - Make sure callback url is set in twitter app settings (you will receive a 401 otherwise) 
 - Set callback url to anything but to twitter itself. The Complete event was never firing in Xamarin.Auth when callbackurl was "http://twitter.com"
 - override onElementChanged event on Android inside the LoginPageRenderer to add auth code
