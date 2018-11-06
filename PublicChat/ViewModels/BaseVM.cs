using System;
using System.Threading.Tasks;
using PublicChat.Pages;
using Xamarin.Forms;

namespace PublicChat.ViewModels
{
    public class BaseVM<T> : BindableObject where T : BasePage
    {
        private T page;
        public T Page { get { return page ?? (page = InitPage()); } }

        protected INavigation Navigation;

        public BaseVM()
        {

        }

        T InitPage()
        {
            T instance = Activator.CreateInstance<T>();
            instance.Init(this);

            Navigation = instance.Navigation;

            return instance;
        }
    }
}
