using System;
using CoreGraphics;
using PublicChat.iOS;
using PublicChat.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ChatEntry), typeof(ChatEntryIOS))]
namespace PublicChat.iOS
{
    public class ChatEntryIOS : EntryRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                Control.Layer.CornerRadius = 28.0f;
                Control.Layer.BorderWidth = 1.0f;
                Control.Layer.BorderColor = new CGColor(0.0f, 0.0f, 0.0f);
                Control.Layer.MasksToBounds = true;
            }
        }
    }
}
