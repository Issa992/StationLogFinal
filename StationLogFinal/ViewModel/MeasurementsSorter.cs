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
  public static class MeasurementsSorter
  {
      static MeasurementsViewModel VM = new MeasurementsViewModel();

        public static void SortMeasurmentsByDate(DateTime date)
        {
            var result = VM.MeasurementsOC.Where(x => x.Date == date);
            VM.MeasurementsOC = (ObservableCollection<Measurement>)result;
        }

        public static void SortMeasurmentsByMonitor(int monitorId)
        {
            var result = VM.MeasurementsOC.Where(x => x.MonitorId == monitorId);
            VM.MeasurementsOC = (ObservableCollection<Measurement>)result;
        }

        public static void SortMeasurmentsByUser(int userId)
        {
            var result = VM.MeasurementsOC.Where(x => x.User.UserId== userId);
            VM.MeasurementsOC = (ObservableCollection<Measurement>)result;
        }

        public static void SortMeasurmentsByAll(DateTime date, int MonitorId, int UserId)
        {
            var result =
                VM.MeasurementsOC.Where(x =>
                    x.Date == date && x.MonitorId == MonitorId && x.User.UserId == UserId);
            VM.MeasurementsOC = (ObservableCollection<Measurement>)result;

        }



    }
}
