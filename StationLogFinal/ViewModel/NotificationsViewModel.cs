using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StationLogFinal.Persistency;
using StationLogWebApplication1;
using StationLogFinal.Handlers;
using System.Windows.Input;
using StationLogFinal.Common;

namespace StationLogFinal.ViewModel
{
    class NotificationsViewModel : NotifyPropertyChange
    {
        #region Property
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string NotApiId = "Notifications";
        const string AlertsApiID = "Alerts";
        WebAPIAsync<Notification> NotWebApi = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        public static IWebAPIAsync<Notification> iWebApiAsyncNot = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        WebAPIAsync<Alert> AlertWebApi = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AlertsApiID);
        public static IWebAPIAsync<Alert> iWebApiAsyncAler = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AlertsApiID);

        public NotificationHandler notificationHandler;

        private Notification _newNotification;
        private Notification _selectedNotification;
        private Alert _newAlert;
        private Alert _selectedAlert;
        private ObservableCollection<Notification> _notificationCO;
        private ObservableCollection<Alert> _alertsCO;

        public Notification selectedNotification
        {
            get => _selectedNotification;
            set
            {
                selectedNotification = value;
                OnPropertyChanged(nameof(selectedNotification));
            }
        }
        public Notification newNotification
        {
            get => _newNotification;
            set
            {
                newNotification = value;
                OnPropertyChanged(nameof(newNotification));
            }
        }
        public Alert newAlert
        {
            get => _newAlert;
            set
            {
                newAlert = value;
                OnPropertyChanged(nameof(newAlert));
            }
        }
        public Alert selectedAlert
        {
            get => _selectedAlert;
            set
            {
                selectedAlert = value;
                OnPropertyChanged(nameof(selectedAlert));
            }
        }
        public ObservableCollection<Notification> notificationCO
        {
            get => _notificationCO;
            set
            {
                notificationCO = value;
                OnPropertyChanged(nameof(notificationCO));
            }
        }
        public ObservableCollection<Alert> alertsCO
        {
            get => _alertsCO;
            set
            {
                alertsCO = value;
                OnPropertyChanged(nameof(alertsCO));
            }
        }
        public ICommand AddNotificationCommand;
        public ICommand AddAlertCommand;
       
        #endregion

        public NotificationsViewModel()
        {
            notificationHandler = new NotificationHandler(this);
            AddAlertCommand = new RelayCommand(notificationHandler.AddAllert);
            AddNotificationCommand = new RelayCommand(notificationHandler.AddNotification);

        }
        #region methods
        private async void LoadAll()
        {

        }

        #endregion


    }
}
