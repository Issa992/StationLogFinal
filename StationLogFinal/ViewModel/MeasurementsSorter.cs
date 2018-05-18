using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel
{
     static class MeasurementsSorter
    {
        static MeasurementsViewModel VM = new MeasurementsViewModel();

        public static void SortMeasurmentsByDate(DateTime date)
        {
            var result = VM.MeasurementsOC.Where(x => x.Date == date);
            var myObservableCollection = new ObservableCollection<Measurement>(result);
            VM.SortednMeasurements = myObservableCollection;
        }
        public static void SortMeasurmentsByStation(int stationId)
        {
            var result = VM.MeasurementsOC.Where(x => x.StationId == stationId);
            var myObservableCollection = new ObservableCollection<Measurement>(result);
            VM.SortednMeasurements = myObservableCollection;
        }

        //        public static void SortMeasurmentsByMonitor(int monitorId)
        //        {
        //            var result = VM.MeasurementsOC.Where(x => x.MonitorID == monitorId);
        //            VM.MeasurementsOC = (ObservableCollection<Measurement>)result;
        //        }

        public static void SortMeasurmentsByUser(int userId)
        {
            var result = VM.MeasurementsOC.Where(x => x.UserId == userId);
            var myObservableCollection = new ObservableCollection<Measurement>(result);
            VM.SortednMeasurements = myObservableCollection;
        }

        public static void SortMeasurmentsByUserAndStation(int userId, int stationId)
        {
            
            var result = VM.MeasurementsOC.Where(x => x.UserId == userId && x.StationId == stationId);
            var myObservableCollection = new ObservableCollection<Measurement>(result);
            VM.SortednMeasurements = myObservableCollection;
        }
        //        public static void SortMeasurmentsByAll(DateTime date, int MonitorId, int UserId)
        //        {
        //            var result =
        //                VM.MeasurementsOC.Where(x =>
        //                    x.date == date && x.MonitorID == MonitorId && x.UserID == UserId);
        //            VM.MeasurementsOC = (ObservableCollection<Measurement>)result;

        //        }



    }
}
