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
                    new Entry(){
                        HeightRequest = 36.0f,
                        BackgroundColor = Color.Transparent,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Keyboard = Keyboard.Create(KeyboardFlags.None)
                    }.Binding(Entry.TextProperty, new Binding("Message")),
                    new Button(){
                        Text = "send",
                        WidthRequest = 48.0f,
                        HeightRequest = 48.0f,
                        VerticalOptions = LayoutOptions.Center
                    }.Binding(Button.CommandProperty, new Binding("OnSendPressed")),
                }
            }, 0, 0);

            grid.Children.Add(new ListView(ListViewCachingStrategy.RecycleElement)
            {
                ItemTemplate = new DataTemplate(() => MessageTemplate()),
                SeparatorVisibility = SeparatorVisibility.None,
                HasUnevenRows = true,
            }.Binding(ItemsView<Cell>.ItemsSourceProperty, new Binding("MessagesCollection")), 0, 1);

            return grid;
        }

        ViewCell MessageTemplate()
        {
            return new ViewCell()
            {
                View = new ContentView()
                {
                    Padding = new Thickness(16.0),
                    Content = new Label().Binding(Label.TextProperty, new Binding("Body"))
                }
            };
        }
    }
}
