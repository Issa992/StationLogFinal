using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;


namespace StationLogFinal.Model
{
    class TaskHandler
    {
        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";

        private IWebAPIAsync<TaskModel> iWebApiAsync;
        public static WebAPIAsync<TaskModel> TwebApiAsync = new WebAPIAsync<TaskModel>(ServerUrl, ApiPrefix, ApiId);
        public WebAPITest<TaskModel> TaskWebApiTest = new WebAPITest<TaskModel>(TwebApiAsync);


        public TaskViewModel TaskViewModel { get; set; }

        public TaskHandler(TaskViewModel taskViewModel)
        {
            TaskViewModel = taskViewModel;
        }

        public async void CreateTask()
        {

            TaskModel task = new TaskModel();


            task.TaskId= TaskViewModel.NewTask.TaskId  ;
            task.DateTime = TaskViewModel.NewTask.DateTime;
            task.Description = TaskViewModel.NewTask.Description;
            task.IsDone = TaskViewModel.NewTask.IsDone;
            task.IsRepeatable = TaskViewModel.NewTask.IsRepeatable;
            task.SchduledDate = TaskViewModel.NewTask.SchduledDate;
            task.StationId = TaskViewModel.NewTask.StationId;
            task.UserId = TaskViewModel.NewTask.UserId;

            await TaskWebApiTest.RunAPITestCreate(task);
            //await iWebApiAsync.Create(task);




        }

        public async void DeleteTask()
        {
            TaskModel task = new TaskModel();
            task.TaskId = TaskViewModel.SelectedTask.TaskId;
            TaskViewModel.TasksColllection.Remove(TaskViewModel.SelectedTask);
            iWebApiAsync = new WebAPIAsync<TaskModel>(ServerUrl, ApiPrefix, ApiId);


            await iWebApiAsync.Delete(task.TaskId);

        }


        //public async void UpdateTask()
        //{
        //    TaskModel task = new TaskModel();

        //    TaskViewModel.NewTask.IsDone = true;
        //    await iWebApiAsync.Update(task.TaskId, task);



        //}

        public async void UpdateTask(bool ischecked, TaskModel task)
        {


            task.IsDone = ischecked;
            await iWebApiAsync.Update(task.TaskId,
                task);
        }




        //    public async void CheckFields()
        //    {

        //        if (CheckFieldsNotBlank())
        //        {
        //            //if (CheckAvailability())
        //            //{
        //            TaskViewModel.TasksColllection.Add(TaskViewModel.NewTask);
        //            CreateTask();
        //            EventCreatedPopUp();
        //            //}

        //        }
        //        else
        //        {
        //            EmptyFieldsPopUp();
        //        }

        //    }

        //    private bool CheckFieldsNotBlank()
        //    {
        //        if ((TaskViewModel.NewTask.UserId == null) || (AddNewEvent.Description == null) ||
        //            (AddNewEvent.Location == null) || (AddNewEvent.Date == null) ||
        //            (AddNewEvent.Time == null) || (AddNewEvent.DateTime == null))

        //        {
        //            return false;
        //        }
        //        else return true;
        //    }



        //    private bool CheckAvailability()
        //    {
        //        if (EventList != null)
        //        {


        //            var Check = EventList.FirstOrDefault(x => x.Name == AddNewEvent.Name);
        //            var Check1 = EventList.FirstOrDefault(x => x.Location == AddNewEvent.Location);
        //            var Check2 = EventList.FirstOrDefault(x => x.Description == AddNewEvent.Description);
        //            var check3 = EventList.FirstOrDefault(x => x.Date == AddNewEvent.Date);
        //            var check4 = EventList.FirstOrDefault(x => x.Time == AddNewEvent.Time);
        //            var check5 = EventList.FirstOrDefault(x => x.DateTime == AddNewEvent.DateTime);

        //            if (((Check == null) && (Check1 == null) && (Check2 == null)
        //                 && (check3 == null) && (check4 == null) && (check5 == null)))
        //            {
        //                ///////////////////////////////////////////.........................................................................................................................................
        //                return true;
        //            }
        //            else
        //            {
        //                EventCreatedPopUp();
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //    private async void EventCreatedPopUp()
        //    {
        //        var dialog = new Windows.UI.Popups.MessageDialog("Your Event Has Been Created. ", "!!!");
        //        dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 1 });

        //        dialog.CancelCommandIndex = 1;

        //        var result = await dialog.ShowAsync();
        //    }

        //    private async void EmptyFieldsPopUp()
        //    {
        //        var dialog = new Windows.UI.Popups.MessageDialog("You Need To Fill All The Fields", "Try Again");
        //        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 1 });
        //        dialog.CancelCommandIndex = 1;
        //        var result = await dialog.ShowAsync();
        //    }
        //}








        ////////////////////////////////////////////////////////////////////////////////////////


        //private string url;

        //public TaskHandler()
        //{
        //    tasksList = new ObservableCollection<Task1>();
        //}

        //public void CreateTask(Task1 task)
        //{
        //    if (task != null)
        //    {
        //        tasksList.Add(task);
        //    }

        //}

        ////public void DeleteTask(int taskID)
        ////{
        ////    foreach (var task in tasksList)
        ////    {
        ////        if (task.ID == taskID)
        ////        {
        ////            tasksList.Remove(task);
        ////        }
        ////    }
        ////}

        ////redo : adding comment to already existing task

        ////public void UpadateTask(int taskId)
        ////{
        ////    var task = tasksList.Where(d => d.taskID == taskId).FirstOrDefault();
        ////    if (task != null)
        ////    {
        ////        //change values...
        ////        //task.Name = "a new name";

        ////    }
        ////}

        //public Task1 GetTask(int taskId)
        //{
        //    return tasksList[taskId];
        //}

        ////public void MakeTaskDone(int taskId)
        ////{
        ////    if (tasksList[taskId].IsDone != true)
        ////    tasksList[taskId].IsDone = true;
        ////}
    }

}

