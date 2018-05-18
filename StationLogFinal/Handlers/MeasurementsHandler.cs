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

namespace StationLogFinal.Handlers
{
    class MeasurementsHandler
    {
      public Measurement measurment;

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
                MeasurementId = MeasurementsViewM.NewMeasurment.MeasurementId,
                MonitorId = MeasurementsViewM.NewMeasurment.MonitorId,
                Date = DateTime.Now,
                Description = MeasurementsViewM.NewMeasurment.Description,
                Value = MeasurementsViewM.NewMeasurment.Value,
                User = CurrentSessioncs.GetCurrentUser(),
                UserId = CurrentSessioncs.GetCurrentUser().UserId,
                StationId = 2
            };
            MeasurementsViewM.MeasurementsOC.Add(measurment);
            await MeasurmentTester.RunAPITestCreate(measurment);
        }

        public async void DeleteMeasurment()
        {
            WebAPITest<Measurement> MeasurmentTester = new WebAPITest<Measurement>(MeasurmentWebApi);
            //await MeasurmentTester.RunAPITestDelete(MeasurementsViewM.SelectedMeasurment.ID);
        }

        public void SortMeasurmentsByUserAndStation()
        {

            var result = MeasurementsViewM.MeasurementsOC.Where(x => x.UserId == CurrentSessioncs.GetCurrentUser().UserId  && x.StationId == 2 );
            var myObservableCollection = new ObservableCollection<Measurement>(result);
            MeasurementsViewM.MeasurementsOC = myObservableCollection;
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
