using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;

namespace StationLogFinal.Handlers
{
    class MeasurementsHandler
    {
        private Measurement measurment;

        public MeasurementsViewModel MeasurementsViewM { get; set; }


        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net";
        const string ApiPrefix = "api";
        const string MeasurmentsApiId = "Measurements";
        WebAPIAsync<Measurement> MeasurmentWebApi = new WebAPIAsync<Measurement>(ServerUrl, ApiPrefix, MeasurmentsApiId);




        public async void AddMeasurment()
        {
            WebAPITest<Measurement> MeasurmentTester = new WebAPITest<Measurement>(MeasurmentWebApi);

            measurment = new Measurement
            {
                //ID = MeasurementsViewM.NewMeasurment.ID,
                //unit = MeasurementsViewM.NewMeasurment.unit,
                //Description = MeasurementsViewM.NewMeasurment.Description,
                //MonitorID = MeasurementsViewM.NewMeasurment.MonitorID,
                //UserID = MeasurementsViewM.NewMeasurment.UserID,
                //Value = MeasurementsViewM.NewMeasurment.Value
            };
            MeasurementsViewM.MeasurementsOC.Add(measurment);
            await MeasurmentTester.RunAPITestCreate(measurment);
        }

        public async void DeleteMeasurment()
        {
            WebAPITest<Measurement> MeasurmentTester = new WebAPITest<Measurement>(MeasurmentWebApi);
            //await MeasurmentTester.RunAPITestDelete(MeasurementsViewM.SelectedMeasurment.ID);
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
