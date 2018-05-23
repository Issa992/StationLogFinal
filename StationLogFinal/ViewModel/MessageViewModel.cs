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



        //public async Task<int> LoadMessages()
        //{
        //  int ID =  CurrentSessioncs.Id;
        //    ObservableCollection<Message> tempCO = new ObservableCollection<Message>(
        //        await iWebApiAsync.Load());
        //    var messagess = from mess in tempCO
        //                    where mess.
        //}
    }
}
