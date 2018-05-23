using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StationLogFinal.Persistency;
using StationLogWebApplication1;
using StationLogFinal.Handlers;
using StationLogFinal.SessionTools;
using System.Windows.Input;
using StationLogFinal.Common;

namespace StationLogFinal.ViewModel
{
    class MessageViewModel : NotifyPropertyChange
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string ApiId = "Messages";
        WebAPIAsync<Message> MeasurmentWebApi = new WebAPIAsync<Message>(ServerUrl, ApiPrefix, ApiId);
        public static IWebAPIAsync<Message> iWebApiAsync = new WebAPIAsync<Message>(ServerUrl, ApiPrefix, ApiId);
        public MessageHandler messageHandler;
        private Message _newMessage;
        private Message _selectedMessage;
        private ObservableCollection<Message> _messagesCO;

        public ICommand sentMessageCommand;
        public ICommand deleteMessageCommand;

        public ObservableCollection<Message> messagesCO
        {
            get => _messagesCO;
            set
            {
                messagesCO = value;
                OnPropertyChanged(nameof(messagesCO));
            }
        }
        public  Message newMessage
        {
            get => _newMessage;
            set
            {
                newMessage = value;
                OnPropertyChanged(nameof(newMessage));
            }
        }
        public Message selectedMessage
        {
            get => _selectedMessage;
            set
            {
                selectedMessage = value;
                OnPropertyChanged(nameof(selectedMessage));
            }
        }
        private string _receiverName;

        public string receiverName
        {
            get => _receiverName;
            set
            {
                receiverName = value;
                OnPropertyChanged(nameof(receiverName));
            }
        }


        public async Task<int> LoadInbox()
        {
            
            ObservableCollection<Message> tempCO = new ObservableCollection<Message>(
                await iWebApiAsync.Load());
            var messagess = from mess in tempCO
                            where mess.ReceiverId == CurrentSessioncs.GetCurrentUserID()
                            select mess;
            messagesCO = new ObservableCollection<Message>(messagess);
            return messagess.Count();
        }
        public MessageViewModel()
        {
            try
            {
                LoadInbox();
            }
            catch (Exception) { }
            messageHandler = new MessageHandler(this);
            newMessage = new Message();
            selectedMessage = new Message();
            deleteMessageCommand = new RelayCommand(messageHandler.DeleteMessage);
            sentMessageCommand = new RelayCommand(messageHandler.SendMessage);
        }
    }
}
