using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Handlers
{
    class NotificationHandler
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string NotApiId = "Notifications";
        const string AlertsApiID = "Alerts";
        WebAPIAsync<Notification> NotWebApi = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        public static IWebAPIAsync<Notification> iWebApiAsyncNot = new WebAPIAsync<Notification>(ServerUrl, ApiPrefix, NotApiId);
        WebAPIAsync<Alert> AlertWebApi = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AlertsApiID);
        public static IWebAPIAsync<Alert> iWebApiAsyncAler = new WebAPIAsync<Alert>(ServerUrl, ApiPrefix, AlertsApiID);

    }
}
