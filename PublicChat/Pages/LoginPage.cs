using System;
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
                        new Entry(){
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            HeightRequest = 56.0f,
                            Keyboard = Keyboard.Create(KeyboardFlags.None)
                        }.Binding(Entry.TextProperty, new Binding("Nickname")),
                        new Button(){
                            Text = "Login",
                            HeightRequest = 56.0f,
                            BackgroundColor = Color.Green,
                            CornerRadius = 28,
                            TextColor = Color.White
                        }.Binding(Button.CommandProperty, new Binding("OnLoginPressed"))
                    }
                }
            };
        }
    }
}
