using StationLogFinal.Persistency;
using StationLogWebApplication1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.ViewModel;
using StationLogFinal.Handlers;
using Windows.UI.Popups;
using StationLogFinal.SessionTools;

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
        public async void SendMessage(Message mes, string receiver)
        {
            UserHandler.GetAllUsers();
            User check= UserHandler.UserListToCheck.FirstOrDefault(x => x.Name == receiver);

            MessageDialog showDialog = new MessageDialog("Are you sure your message" +
                " is ready to be sent?");
            showDialog.Commands.Add(new UICommand("Yes") { Id = 0 });
            showDialog.Commands.Add(new UICommand("No") { Id = 1 });
            showDialog.DefaultCommandIndex = 0;
            showDialog.CancelCommandIndex = 1;
            var result = await showDialog.ShowAsync();

            if ((int)result.Id == 0)
            {
                if (check != null)
                {
                    await WebApi.Create(mes);
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Cannot find a receiver", "Error");
                    await msg.ShowAsync();
                }
            }
            else
            {
            }
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
