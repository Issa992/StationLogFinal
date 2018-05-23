using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogWebApplication1;
using StationLogFinal.Persistency;

namespace StationLogFinal.Handlers
{
    class MessageHandler
    {
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string MeasurmentsApiId = "Messages";
        WebAPIAsync<Message> MeasurmentWebApi = new WebAPIAsync<Message>(ServerUrl, ApiPrefix, MeasurmentsApiId);
    }
}
