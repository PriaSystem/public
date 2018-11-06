using System;
using PublicChat.Views;
using Xamarin.Forms;

namespace PublicChat.Pages
{
    public class LoginPage : BasePage
    {
        protected override View CreateContent()
        {
            Title = "Simple Chat";
            NavigationPage.SetBackButtonTitle(this, "");

            return new ContentView()
            {
                Padding = new Thickness(32.0f),
                Content = new StackLayout()
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        //todo entry and button
                    }
                }
            };
        }
    }
}
