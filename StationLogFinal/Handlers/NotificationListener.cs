using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StationLogFinal.Persistency;
using StationLogWebApplication1;
using Windows.UI.Popups;

namespace StationLogFinal.Handlers
{
    public static class NotificationListener
    {
        public static Thread Listener; //<- core of the class

        private const string ServerUrl = "http://stationlogwebapplication120180521125426.azurewebsites.net";
        private const string ApiPrefix = "api";
        private const string ApiId = "Messages";
        private const string NotApiID = "Notifications";
        private const string AlertApiID = "Alerts";

        /// <summary>
        /// constructor with all its beauty
        /// </summary>
        public static void StartListener()
        {
            Listener = new Thread(Initialize);
        }

        /// <summary>
        /// Recurrent method prepared to be passed as a parameter to the thread
        /// </summary>
        private static async void Initialize()
        {
            bool isFinished1 = await CheckForNewNotification();
            bool isFinished = await CheckForNewMessages();
            Thread.Sleep(60000);
            Initialize();
        }
        /// <summary>
        /// Shows pop up if there is new notification
        /// </summary>
        /// <returns>Always returns true, just because i needed it ro return sth</returns>
        private static async Task<bool> CheckForNewNotification()
        {
            NotificationHandler handler = new NotificationHandler();
            await handler.LoadAll();
            var query = from not in handler.notifications
                        where not.IsRed == false
                        select not;
            var query1 = from al in handler.alerts
                         where al.IsRed == false || al.IsToggled == true
                         select al;
            int count = query.Count() + query1.Count();
            if (count > 0)
            {
                MessageDialog msg = new MessageDialog("You have new notifications or alerts waiting for you!", "New Notifications!");
                await msg.ShowAsync();
            }

            return true;
        }
        /// <summary>
        /// Shows Pop up if there is any new message
        /// </summary>
        /// <returns>Always returns true, just because i needed it ro return sth lol</returns>
        private static async Task<bool> CheckForNewMessages()
        {
            MessagesHandler handler = new MessagesHandler();
             handler.LoadInbox();
            var query = from mess in handler.Inbox
                        where mess.IsRead == false
                        select mess;
            int i = query.Count();
            if (i > 0)
            {
                MessageDialog msg = new MessageDialog("You have unread message(s), check your inbox", "New Messages!");
                await msg.ShowAsync();
            }
            return true;
        }
    }
}
