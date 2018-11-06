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
        private string mNickname;
        public string Nickname
        {
            get { return mNickname; }
            set
            {
                if (mNickname != value)
                {
                    mNickname = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool mIsLoading;
        public bool IsLoading
        {
            get { return mIsLoading; }
            set
            {
                if (mIsLoading != value)
                {
                    mIsLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        readonly RealtimeDatabase DB = new RealtimeDatabase();

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
                    if (ValidateNickname())
                    {
                        CreateAccount();
                    }
                }));
            }
        }

        bool ValidateNickname()
        {
            return !String.IsNullOrEmpty(Nickname) && Nickname.Length > 3;
        }

        async void CreateAccount()
        {
            IsLoading = true;


            User user = new User()
            {
                Uid = DB.UID,
                Nickname = Nickname,
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            bool success = await DB.CreateUser(user);

            await DB.SendMessage(new Message()
            {
                Nickname = Nickname,
                Body = $"{Nickname} joined !",
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            });

            if (success)
            {
                await Navigation.PushAsync(new ChatVM(user).Page);
            }

            IsLoading = false;
        }
    }
}
