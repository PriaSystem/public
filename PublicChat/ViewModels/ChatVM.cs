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
        private ObservableCollection<Message> mMessagesCollection;
        public ObservableCollection<Message> MessagesCollection
        {
            get { return mMessagesCollection; }
            set
            {
                if (mMessagesCollection != value)
                {
                    mMessagesCollection = value;
                    OnPropertyChanged();
                }
            }
        }

        private string mMessage;
        public string Message
        {
            get { return mMessage; }
            set
            {
                if (mMessage != value)
                {
                    mMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public User User { get; private set; }

        readonly RealtimeDatabase DB = new RealtimeDatabase();

        public ChatVM(User user)
        {
            User = user;
            MessagesCollection = new ObservableCollection<Message>();

            SubscribeMessages();
        }

        private Command mOnSendPressed;
        public Command OnSendPressed
        {
            get
            {
                return mOnSendPressed ?? (mOnSendPressed = new Command(async (arg) =>
                {
                    if (String.IsNullOrEmpty(Message))
                    {
                        return;
                    }

                    await DB.SendMessage(new Message()
                    {
                        Nickname = User.Nickname,
                        Body = Message,
                        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                    });

                    Message = "";
                }));
            }
        }

        void SubscribeMessages()
        {
            DB.SubscribeToNewMessages((message) =>
            {
                MessagesCollection.Insert(0, message);
            });
        }
    }
}
