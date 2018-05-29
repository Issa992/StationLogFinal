using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;
using StationLogWebApplication1.Models;

namespace StationLogFinal.Handlers
{
    class MeasurementsHandler
    {
      public Measurement measurment;

         public MeasurementsViewModel MeasurementsViewM { get; set; }

        //oldDB http://stationlogwebapplication120180426012243.azurewebsites.net
        //newDB http://stationlogsystemwebapplication20180521105958.azurewebsites.net

        const string ServerUrl = "http://stationlogwebapplication120180521125426.azurewebsites.net";
        const string ApiPrefix = "api";
        const string MeasurmentsApiId = "Measurements";
        WebAPIAsync<Measurement> MeasurmentWebApi = new WebAPIAsync<Measurement>(ServerUrl, ApiPrefix, MeasurmentsApiId);




        public async void AddMeasurment()
        {
            WebAPITest<Measurement> MeasurmentTester = new WebAPITest<Measurement>(MeasurmentWebApi);

            measurment = new Measurement
            {
                MeasurementId = MeasurementsViewM.NewMeasurment.MeasurementId,
                MonitorId = MeasurementsViewM.NewMeasurment.MonitorId,
                UserId = CurrentSessioncs.GetCurrentUser().UserId,
                StationId = MeasurementsViewM.NewMeasurment.StationId,
                Date = MeasurementsViewM.NewMeasurment.Date,
                Description = MeasurementsViewM.NewMeasurment.Description,
                Value = MeasurementsViewM.NewMeasurment.Value             

            };
           
            await MeasurmentTester.RunAPITestCreate(measurment);
        }

        public async void DeleteMeasurment()
        {
            MeasurementsViewM.MeasurementsOC.Remove(MeasurementsViewM.SelectedMeasurment);
            MeasurmentWebApi = new WebAPIAsync<Measurement>(ServerUrl, ApiPrefix, MeasurmentsApiId);


            await MeasurmentWebApi.Delete(MeasurementsViewM.SelectedMeasurment.MeasurementId);
        }

     
        public MeasurementsHandler(MeasurementsViewModel measurementsViewModel)
        {
            MeasurementsViewM = measurementsViewModel;
        }

        public MeasurementsHandler()
        {
            
        }

    }
}
