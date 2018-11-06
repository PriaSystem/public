using System;
using Xamarin.Forms;

namespace PublicChat.Pages
{
    public abstract class BasePage : ContentPage
    {
        public void Init(object context)
        {
            BindingContext = context;
            
            Content = CreateContent();
        }

        protected abstract View CreateContent();
    }
}
