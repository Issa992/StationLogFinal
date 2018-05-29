using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.SessionTools;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;


namespace StationLogFinal.Model
{
    class TaskHandler
    {
        //     oldDB const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net";
        //NEw DB http://stationlogsystemwebapplication20180521105958.azurewebsites.net

        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
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
    
        public async Task CreateTask()
        {

            TaskModel task = new TaskModel();


            task.TaskId= TaskViewModel.NewTask.TaskId;
            task.DateTime = TaskViewModel.NewTask.DateTime;
            task.Description = TaskViewModel.NewTask.Description;
            task.IsDone = TaskViewModel.NewTask.IsDone;
            task.IsRepeatable = TaskViewModel.NewTask.IsRepeatable;
            task.SchduledDate = TaskViewModel.NewTask.SchduledDate;
            task.StationId = TaskViewModel.NewTask.StationId;
            task.UserId = CurrentSessioncs.GetCurrentUser().UserId;

            await TaskWebApiTest.RunAPITestCreate(task);
        }

        public async void DeleteTask()
        {
            TaskModel task = new TaskModel();
            task.TaskId = TaskViewModel.SelectedTask.TaskId;
            TaskViewModel.TasksColllection.Remove(TaskViewModel.SelectedTask);
            iWebApiAsync = new WebAPIAsync<TaskModel>(ServerUrl, ApiPrefix, ApiId);
            await iWebApiAsync.Delete(task.TaskId);
            await TaskViewModel.LoadTasks();

        }


        public async Task UpdateTask(TaskModel task1)
        {
            TaskModel task = new TaskModel();
            task1.IsDone = task.IsDone;
            task1.IsDone = TaskViewModel._SelectedTask.IsDone;
            TaskViewModel.NewTask.IsDone = true;
            await iWebApiAsync.Update(task1.TaskId,task1);



        }

        public TaskHandler()
        {
            
        }




        public async void CheckFields()
        {

            if (CheckFieldsNotBlank())
            {

                if (CheckAvailability())
                {
                    TaskViewModel.TasksColllection.Add(TaskViewModel.NewTask);
                    await CreateTask();
                    TaskCreatedPopUp();
                }

            }
            else
            {
                EmptyTaskFieldsPopUp();
            }

        }

        private bool CheckFieldsNotBlank()
        {
            if ((TaskViewModel.NewTask.TaskId == null) || (TaskViewModel.NewTask.DateOffset == null) ||
                (TaskViewModel.NewTask.DateOffsetSchduledDate== null) ||  (TaskViewModel.NewTask.Description == null) ||
                (TaskViewModel.NewTask.StationId == null) || (TaskViewModel.NewTask.IsRepeatable == null) )

            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private bool CheckAvailability()
        {
            if (TaskViewModel.TasksColllection != null)
            {


                var Check = TaskViewModel.TasksColllection.FirstOrDefault(x => x.TaskId == TaskViewModel.NewTask.TaskId);
                var Check1 = TaskViewModel.TasksColllection.FirstOrDefault(x => x.DateOffset == TaskViewModel.NewTask.DateOffset);
                var Check2 = TaskViewModel.TasksColllection.FirstOrDefault(x => x.Description == TaskViewModel.NewTask.Description);
                var check3 = TaskViewModel.TasksColllection.FirstOrDefault(x => x.DateOffsetSchduledDate == TaskViewModel.NewTask.DateOffsetSchduledDate);
                var check4 = TaskViewModel.TasksColllection.FirstOrDefault(x => x.IsRepeatable == TaskViewModel.NewTask.IsRepeatable);
                var check5 = TaskViewModel.TasksColllection.FirstOrDefault(x => x.StationId == TaskViewModel.NewTask.StationId);

                if (((Check == null) && (Check1 == null) && (Check2 == null)
                     && (check3 == null) && (check4 == null) ))
                {
                    return false;
                }
                else
                {
                    
                    return true;
                }
            }
            else
            {
                TaskCreatedPopUp();
                return true;
            }
        }
        private async void TaskCreatedPopUp()
        {
            var dialog = new Windows.UI.Popups.MessageDialog("The Task Has Been Created. ", "!!!");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("OK") { Id = 1 });

            dialog.CancelCommandIndex = 1;

            var result = await dialog.ShowAsync();
        }

        private async void EmptyTaskFieldsPopUp()
        {
            var dialog = new Windows.UI.Popups.MessageDialog("You Need To Fill All The Fields", "Try Again");
            dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 1 });
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
        }
    }








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


