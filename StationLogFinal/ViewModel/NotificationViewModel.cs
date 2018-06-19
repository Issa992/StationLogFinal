using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using StationLogFinal.Common;
using StationLogWebApplication1.Models;
using StationLogFinal.Persistency;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel 
{
    public class NotificationViewModel: NotifyPropertyChange
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string NotificationId = "Notifications";
        const string AlertsID = "Alerts";

        static IWebAPIAsync<TaskModel> NotificationWebApi = new WebAPIAsync<TaskModel>(ServerUrl, ApiPrefix, NotificationId);

    }
}
