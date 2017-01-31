# Trll
This is my attempt at making a clone of the Trello® Android and iOS app using Xamarin.Forms

I used a combination of the [andoird](https://pttrns.com/applications/350#348) and [iOS](https://pttrns.com/applications/559#6760) reference screenshots from [Pttrns.com](https://pttrns.com/), and the actual application installed of said OSes.

This application uses the actual [Trello Api](https://developers.trello.com/).

This is a work in progress, I've learnt a fair bit of things about Xamarin.Forms and XAML in general, although I still have a whole world of things to learn.

### Running the app

To run this app you'll need to:
* Have the [Xamarin platform](https://www.xamarin.com/platform) installed.
* Go to `Trll.Core.Constants` and set the `Key` and `Token` properties with the values mentioned below:
  * Generate a Trello App key [here](https://trello.com/app-key)
  * Generate a Trello api token by clicking `Generate a token` [here](https://trello.com/app-key) (this is while the authentication system is still in development)
