using System;
using Xamarin.Forms;

namespace PublicChat
{
    public static class ViewExtension
    {
        public static View Binding(this View view, BindableProperty property, Binding binding)
        {
            view.SetBinding(property, binding);

            return view;
        }
    }
}
