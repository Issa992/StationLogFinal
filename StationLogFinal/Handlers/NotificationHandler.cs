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
    public class NotificationHandler
    {
        private const string ServerUrl = "http://stationlogwebapplication120180521125426.azurewebsites.net";
        private const string ApiPrefix = "api";
        private const string NotApiId = "Notifications";
        private const string AllApiId = "Alerts";
        public WebAPIAsync<Alert> AWebApi = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AllApiId);
        public WebAPIAsync<Notification> NWebApi = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        public ObservableCollection<Notification> notifications;
        public ObservableCollection<Alert> alerts;
        

        public NotificationHandler()
        {
            LoadAll();
        }


        public async Task<bool> LoadAll()
        {
            List<Notification> nots = await NWebApi.Load();
            List<Alert> als = await AWebApi.Load();
            return true;
        }

        public async void AddNotification(Notification not)
        {
            await NWebApi.Create(not);
        }
        public async void AddAllert(Alert alert)
        {
            await AWebApi.Create(alert);
        }
        public void ReadAlert (Alert alert)
        {
            alert.IsRed = true;
        }
        public void ReadNotification(Notification not)
        {
            not.IsRed = true;
        }
    }
}
