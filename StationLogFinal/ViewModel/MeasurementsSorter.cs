using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Views;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel
{
     static class MeasurementsSorter
    {
        static MeasurementsViewModel VM = new MeasurementsViewModel();
        
        
        public static List<Measurement> SortMeasurmentsByDate(DateTime date)
        {
            var query = from measure in VM.MeasurementsOC where (measure.Date == date) select measure;
            return query.ToList();
        }
        public static List<Measurement> SortMeasurmentsByStation(int monitorId)
        {
           
            var query = from measure in VM.MeasurementsOC where (measure.MonitorId == monitorId) select measure;
            return query.ToList();
            //foreach (var measure in query.ToList())
            //{
            //    VM.SortednMeasurements.Add(new Measurement
            //    {
            //        MeasurementId = measure.MeasurementId,
            //        Date = measure.Date,
            //        Description = measure.Description,
            //        MonitorId = measure.MonitorId,
            //        StationId = measure.StationId,
            //        User = measure.User,
            //        UserId = measure.UserId,
            //        Value = measure.Value

            //    });
            //}
            //var myObservableCollection = new ObservableCollection<Measurement>(query);
            //VM.SortednMeasurements = myObservableCollection;


        }

     

        public static List<Measurement> SortMeasurmentsByUser(int userId)
        {

            var query = from measure in VM.MeasurementsOC where (measure.UserId == userId) select measure;
            return query.ToList();
        }

        public static List<Measurement> SortMeasurmentsByUserAndStation(int userId, int stationId)
        {

            var query = from measure in VM.MeasurementsOC where (measure.UserId == userId && measure.StationId == stationId) select measure;
            return query.ToList();
        }
      



    }
}
