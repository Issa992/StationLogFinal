using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Views;
using StationLogWebApplication1;
using StationLogWebApplication1.Models;

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
        public static List<Measurement> SortMeasurmentsByStation(int stationId)
        {
           
            var query = from measure in VM.MeasurementsOC where (measure.StationId == stationId) select measure;
            return query.ToList();
        }

     

        public static List<Measurement> SortMeasurmentsByUser(int userId)
        {

            var query = from measure in VM.MeasurementsOC where (measure.UserId == userId) select measure;
            return query.ToList();
        }

  
      



    }
}
