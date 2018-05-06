using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.ViewModel;

namespace StationLogFinal.Model
{
    class LogsHandler
    {
        private Measurment measurment;
        private Comment comment;
        public LogsViewModel LogsViewModel { get; set; }
        public void AddMeasurment()
        {
            measurment = new Measurment
            {
                ID = LogsViewModel.NewMeasurment.ID,
                unit = LogsViewModel.NewMeasurment.unit,
                Description = LogsViewModel.NewMeasurment.Description,
                MonitorID = LogsViewModel.NewMeasurment.MonitorID,
                UserID = LogsViewModel.NewMeasurment.UserID,
                Value = LogsViewModel.NewMeasurment.Value
            };
            LogsViewModel.Measurments.Add(measurment);
        }

        public void DeleteMeasurment()
        {

            LogsViewModel.Measurments.Remove(LogsViewModel.SelectedMeasurment);
        }

        public void AddComment()
        {
            comment = new Comment
            {
                //rewrite to add id. logid, userid automatically + db
                ID = LogsViewModel.NewComment.ID,
                LogID = LogsViewModel.NewComment.LogID,
                comment = LogsViewModel.NewComment.comment,
                time = DateTime.Now,
                UserID = LogsViewModel.NewComment.UserID

            };
            LogsViewModel.Comments.Add(comment);

        }

        public void DeleteComment()
        {
            LogsViewModel.Comments.Remove(LogsViewModel.SelectedComment);
        }

        public LogsHandler(LogsViewModel logsViewModel)
        {
            LogsViewModel = logsViewModel;
        }


    }
}
