using System;
using System.Diagnostics;
using PublicChat.Entity;
using PublicChat.Fire;
using PublicChat.Pages;
using Xamarin.Forms;

namespace PublicChat.ViewModels
{
    public class LoginVM : BaseVM<LoginPage>
    {
        public LoginVM()
        {

        }

        private Command mOnLoginPressed;
        public Command OnLoginPressed
        {
            get
            {
                return mOnLoginPressed ?? (mOnLoginPressed = new Command((arg) =>
                {
                    //todo create account
                }));
            }
        }

        async void CreateAccount()
        {
            bool success = false;

            //todo create user account

            if (success)
            {
                //todo open chat
            }
        }
    }
}
