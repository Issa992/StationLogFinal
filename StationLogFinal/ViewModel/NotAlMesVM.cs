using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationLogFinal.Handlers;
using StationLogWebApplication1;
using System.Threading.Tasks;
using StationLogFinal.Common;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StationLogFinal.ViewModel
{
    /// <summary>
    /// Notification, Alerts and Messeges View Model, brand new
    /// All in one!
    /// Czasem nawet działa
    /// </summary>
    class NotAlMesVM : NotifyPropertyChange
    {
        #region properties
        private MessagesHandler messagesHandler;
        private NotificationHandler notificationHandler;
        private ObservableCollection<Notification> _notificationOC;
        private ObservableCollection<Alert> _alertOC;
        private ObservableCollection<Message> _messageOC;

        public ObservableCollection<Notification> NotificationOC
        {
            get => _notificationOC;
            set
            {
                NotificationOC = value;
                OnPropertyChanged(nameof(NotificationOC));
            }
        }
        public ObservableCollection<Alert> AlertsOC
        {
            get => _alertOC;
            set
            {
                AlertsOC = value;
                OnPropertyChanged(nameof(AlertsOC));
            }
        }
        public ObservableCollection<Message> MessagesOC
        {
            get => _messageOC;
            set
            {
                MessagesOC = value;
                OnPropertyChanged(nameof(MessagesOC));
            }
        }
        public ICommand SendMessage;
        public ICommand DeleteMessage;
        public ICommand ReadMessage;
        public ICommand ReadNotification;
        public ICommand ReadAlert;
        public ICommand AddNotification;
        public ICommand AddAlert;

        private Message _selectedMessage;
        private Message _newMessage;
        private Alert _selectedAlert;
        private Alert _newAlert;
        private Notification _selectedNotification;
        private Notification _newNotification;

        public Notification SelectedNotification
        {
            get => _selectedNotification;
            set
            {
                SelectedNotification = value;
                OnPropertyChanged(nameof(SelectedNotification));
            }
        }
        public Notification NewNotification
        {
            get => _newNotification;
            set
            {
                NewNotification = value;
                OnPropertyChanged(nameof(NewNotification));
            }
        }
        public Alert NewAlert
        {
            get => _newAlert;
            set
            {
                NewAlert = value;
                OnPropertyChanged(nameof(NewAlert));
            }
        }
        public Alert SelectedAlert
        {
            get => _selectedAlert;
            set
            {
                SelectedAlert = value;
                OnPropertyChanged(nameof(SelectedAlert));
            }
        }
        public Message SelectedMessage
        {
            get => _selectedMessage;
            set
            {
                SelectedMessage = value;
                OnPropertyChanged(nameof(SelectedMessage));
            }
        }
        public Message NewMessage
        {
            get => _newMessage;
            set
            {
                NewMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        #endregion
        public NotAlMesVM()
        {
            NotificationListener.StartListener();
            messagesHandler = new MessagesHandler();
            notificationHandler = new NotificationHandler();
            messagesHandler.LoadInbox();
            notificationHandler.LoadAll();
            SendMessage = new RelayCommand(_sendMessage);
            DeleteMessage = new RelayCommand(_deleteMessage);
            ReadMessage = new RelayCommand(_readMessage);
            ReadNotification = new RelayCommand(_readNotification);
            ReadAlert = new RelayCommand(_readAlert);
            AddNotification = new RelayCommand(_addNotification);
            AddAlert = new RelayCommand(_addAlert);
        }

        #region method for commands
        private void _sendMessage()
        {
            messagesHandler.SendMessage(NewMessage);
        }
        private void _deleteMessage()
        {
            messagesHandler.DeleteMessage(SelectedMessage);
        }
        private void _readMessage()
        {
            messagesHandler.ReadMessage(SelectedMessage);
        }
        private void _addAlert()
        {
            notificationHandler.AddAllert(NewAlert);
        }
        private void _readAlert()
        {
            notificationHandler.ReadAlert(SelectedAlert);
        }
        private void _addNotification()
        {
            notificationHandler.AddNotification(NewNotification);
        }
        private void _readNotification()
        {
            notificationHandler.ReadNotification(SelectedNotification);
        }
        #endregion
    }
}
