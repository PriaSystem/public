using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PublicChat.Entity;
using PublicChat.Fire;
using PublicChat.Pages;
using Xamarin.Forms;

namespace PublicChat.ViewModels
{
    public class ChatVM : BaseVM<ChatPage>
    {
        public User User { get; private set; }

        public ChatVM(User user)
        {
            User = user;
        }

        private Command mOnSendPressed;
        public Command OnSendPressed
        {
            get
            {
                return mOnSendPressed ?? (mOnSendPressed = new Command((arg) =>
                {
                    //todo send message
                }));
            }
        }

        void SubscribeMessages()
        {
            //todo add new message
        }
    }
}
