using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;

namespace StationLogFinal.Handlers
{
    class MeasurementsHandler
    {
        private Measurment measurment;

        public MeasurementsViewModel MeasurementsViewM { get; set; }


        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net";
        const string ApiPrefix = "api";
        const string MeasurmentsApiId = "Measurements";
        WebAPIAsync<Measurment> MeasurmentWebApi = new WebAPIAsync<Measurment>(ServerUrl, ApiPrefix, MeasurmentsApiId);




        public async void AddMeasurment()
        {
            WebAPITest<Measurment> MeasurmentTester = new WebAPITest<Measurment>(MeasurmentWebApi);

            measurment = new Measurment
            {
                ID = MeasurementsViewM.NewMeasurment.ID,
                unit = MeasurementsViewM.NewMeasurment.unit,
                Description = MeasurementsViewM.NewMeasurment.Description,
                MonitorID = MeasurementsViewM.NewMeasurment.MonitorID,
                UserID = MeasurementsViewM.NewMeasurment.UserID,
                Value = MeasurementsViewM.NewMeasurment.Value
            };
            MeasurementsViewM.MeasurementsOC.Add(measurment);
            await MeasurmentTester.RunAPITestCreate(measurment);
        }

        public async void DeleteMeasurment()
        {
            WebAPITest<Measurment> MeasurmentTester = new WebAPITest<Measurment>(MeasurmentWebApi);
            await MeasurmentTester.RunAPITestDelete(MeasurementsViewM.SelectedMeasurment.ID);
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
