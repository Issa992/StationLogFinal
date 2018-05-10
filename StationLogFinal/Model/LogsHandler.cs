using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;

namespace StationLogFinal.Model
{
    class LogsHandler
    {
        private Measurment measurment;
        private Comment comment;
        public LogsViewModel LogsViewModel { get; set; }
        private IWebAPIAsync<Comment> iWebApiAsync;

        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";

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

        public async void AddComment()
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
           
            await iWebApiAsync.Create(comment);

        }

        public async void DeleteComment()
        {
            comment = new Comment();
            comment.ID = LogsViewModel.SelectedComment.ID;
            LogsViewModel.CommentsOC.Remove(LogsViewModel.SelectedComment);
            iWebApiAsync = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
            await iWebApiAsync.Delete(comment.ID);

        }





        public LogsHandler(LogsViewModel logsViewModel)
        {
            LogsViewModel = logsViewModel;
        }


    }
}
