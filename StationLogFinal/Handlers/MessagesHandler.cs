using StationLogFinal.Persistency;
using StationLogWebApplication1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Handlers
{
    public class MessagesHandler
    {
        private const string ServerUrl = "http://stationlogwebapplication120180521125426.azurewebsites.net";
        private const string ApiPrefix = "api";
        private const string ApiId = "Messages";
        public WebAPIAsync<Message> WebApi = new WebAPIAsync<Message>(ServerUrl, ApiPrefix, ApiId);
        public ObservableCollection<Message> Inbox;

        public MessagesHandler()
        {
            LoadInbox();
        }

        public async void LoadInbox()
        {
           List<Message> templist = await WebApi.Load();
            var inboxquerry = from mess in templist
                              where mess.ReceiverId == SessionTools.CurrentSessioncs.GetCurrentUserID()
                              select mess;
            Inbox = new ObservableCollection<Message>(inboxquerry);
        }
        public async void SendMessage(Message mes)
        {
            await WebApi.Create(mes);
        }
        public void ReadMessage(Message mes)
        {
            mes.IsRead = true;
        }
        public async void DeleteMessage(Message mes)
        {
            await WebApi.Delete(mes.MessageId);
            
        }
    }
}
