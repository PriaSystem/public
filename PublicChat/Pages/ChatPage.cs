using System;
using Xamarin.Forms;

namespace PublicChat.Pages
{
    public class ChatPage : BasePage
    {
        protected override View CreateContent()
        {
            Title = "Chat Room";

            Grid grid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition(){ Height = GridLength.Auto },
                    new RowDefinition(){ Height = GridLength.Star }
                }
            };

            grid.Children.Add(new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HeightRequest = 56.0f,
                Padding = new Thickness(16.0f, 0.0f),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Orange,
                Children = {
                    //todo entry and button
                }
            }, 0, 0);

            grid.Children.Add(new ListView(ListViewCachingStrategy.RecycleElement)
            {
                //todo listview
            }, 0, 1);

            return grid;
        }

        ViewCell MessageTemplate()
        {
            return new ViewCell()
            {
                View = new ContentView()
                {
                    Padding = new Thickness(16.0),
                    //todo message cell
                }
            };
        }
    }
}
