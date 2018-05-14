using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;

namespace StationLogFinal.ViewModel
{
  public static class MeasurementsSorter
  {
      static MeasurementsViewModel VM = new MeasurementsViewModel();

        public static void SortMeasurmentsByDate(DateTime date)
        {
            var result = VM.MeasurementsOC.Where(x => x.date == date);
            VM.MeasurementsOC = (ObservableCollection<Measurment>)result;
        }

        public static void SortMeasurmentsByMonitor(int monitorId)
        {
            var result = VM.MeasurementsOC.Where(x => x.MonitorID == monitorId);
            VM.MeasurementsOC = (ObservableCollection<Measurment>)result;
        }

        public static void SortMeasurmentsByUser(int userId)
        {
            var result = VM.MeasurementsOC.Where(x => x.UserID == userId);
            VM.MeasurementsOC = (ObservableCollection<Measurment>)result;
        }

        public static void SortMeasurmentsByAll(DateTime date, int MonitorId, int UserId)
        {
            var result =
                VM.MeasurementsOC.Where(x =>
                    x.date == date && x.MonitorID == MonitorId && x.UserID == UserId);
            VM.MeasurementsOC = (ObservableCollection<Measurment>)result;

        }



    }
}
