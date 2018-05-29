using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StationLogFinal.Persistency;
using StationLogWebApplication1;
using StationLogFinal.Handlers;
using StationLogFinal.ViewModel;
using Windows.UI.Popups;

namespace StationLogFinal.Handlers
{
    class NotificationHandler
    {
        #region property
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string NotApiId = "Notifications";
        const string AlertsApiID = "Alerts";
        WebAPIAsync<Notification> NotWebApi = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        public static IWebAPIAsync<Notification> iWebApiAsyncNot = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        WebAPIAsync<Alert> AlertWebApi = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AlertsApiID);
        public static IWebAPIAsync<Alert> iWebApiAsyncAler = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AlertsApiID);

        public NotificationsViewModel ViewModel;
        #endregion
        #region Constructor
        public NotificationHandler (NotificationsViewModel VM)
        {
            this.ViewModel = VM;
        }
        #endregion
        #region Methods
        public async void AddNotification()
        {
            try
            {
                Notification objectToPut = ViewModel.newNotification;
                ViewModel.notificationCO.Add(objectToPut);
                await NotWebApi.Create(objectToPut);
            }
            catch(Exception e)
            {
                MessageDialog popup = new MessageDialog($"Error occured while" +
                    $" trying to add Notification./n{e.ToString()}");
            }
            
        }
        public async void AddAllert()
        {
            try
            {
                Alert objectToPut = ViewModel.newAlert;
                ViewModel.alertsCO.Add(objectToPut);
                await AlertWebApi.Create(objectToPut);
            }
            catch (Exception e)
            {
                MessageDialog popup = new MessageDialog($"Error occured while" +
                    $" trying to add Alert./n{e.ToString()}");
            }
            
        }
        public string ReadNotification()
        {
            ViewModel.selectedNotification.IsRed = true;
            return ViewModel.selectedNotification.Message;
        }
        public string ReadAlert()
        {
            ViewModel.selectedAlert.IsRed = true;
            return ViewModel.selectedAlert.Message;
        }
        public int GetNumberOfNewNotification()
        {
            var result = from Notif in ViewModel.notificationCO
                         where Notif.IsRed == false
                         select Notif;
            return result.Count<Notification>();
        }
        public int GetNumberOfNewAlerts()
        {
            var result = from alert in ViewModel.alertsCO
                         where alert.IsRed = false || alert.IsToggled == true
                         select alert;
            return result.Count();
        }

        #endregion
    }
}
