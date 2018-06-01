using System.Linq;
using System.Threading.Tasks;
using StationLogWebApplication1;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace StationLogFinal.Handlers
{
    public class MessageHandler
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string MeasurmentsApiId = "Messages";
        WebAPIAsync<Message> MessageWebApi = new WebAPIAsync<Message>(ServerUrl, ApiPrefix, MeasurmentsApiId);
        const string UsersApiID = "Users";
        WebAPIAsync<User> UserWebApi = new WebAPIAsync<User>(ServerUrl, ApiPrefix, UsersApiID);
        private User _receiver;
        public MessageViewModel ViewModel;

        public MessageHandler(MessageViewModel VM)
        {
            ViewModel = VM;
        }

        public async Task<bool> CheckIfPossibleReceiver()
        {
            string name = ViewModel.receiverName;

            ObservableCollection<User> tempUsers = new ObservableCollection<User>();
            try
            {
                tempUsers = new ObservableCollection<User>(
                await UserWebApi.Load());
            }
            catch { }
            User user = tempUsers.FirstOrDefault(x => x.Name == name);
            if (user != null)
            {
                _receiver = user;
                return true;
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("Could not" +
                    " find receiver with such a name");
                return false;
            }
        }
        public async void SendMessage()
        {
            bool condition = await CheckIfPossibleReceiver();
            if (condition)
            {
                await MessageWebApi.Create(ViewModel.newMessage);
               
            }
            else
            {
              
            }
        }
        public async void DeleteMessage()
        {
            try
            {
                await MessageWebApi.Delete(ViewModel.selectedMessage.MessageId);
            }
            catch { }
           
        }
    }
}
