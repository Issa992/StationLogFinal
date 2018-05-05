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


namespace StationLogFinal.Model
{
    class TaskHandler
    {
        //
        //private ObservableCollection<Task1> tasksList;

        public TaskViewModel TaskViewModel { get; set; }

        public TaskHandler(TaskViewModel taskViewModel)
        {
            TaskViewModel = taskViewModel;
        }
        public ObservableCollection<Task1> taskss { get; set; }

        public async void CreateTask()
        {
            Task1 task = new Task1();
            
            task.TaskId = TaskViewModel.NewTask.TaskId;
            task.DateTime = TaskViewModel.NewTask.DateTime;
            task.Description = TaskViewModel.NewTask.Description;
            task.IsDone = TaskViewModel.NewTask.IsDone;
            task.IsRepeatable = TaskViewModel.NewTask.IsRepeatable;
            task.SchduledDate = TaskViewModel.NewTask.SchduledDate;
            task.StationId = TaskViewModel.NewTask.StationId;
            task.UserId = TaskViewModel.NewTask.UserId;
            //taskss.Add(task);
            TaskViewModel.Tasks.Add(task);
            await new TaskWebAPI().SaveTask(task);

            
            //new TaskWebAPI().SaveTask(task);

            //TaskViewModel.TaskCatalogSingleton.TaskObservableCollection.Add(task);

            //var tasks = new TaskWebAPI().GetTaskAsync();

            //TaskViewModel.TaskCatalogSingleton.TaskObservableCollection.Clear();


            //foreach (var task1 in tasks)
            //{
            //    TaskViewModel.TaskCatalogSingleton.TaskObservableCollection.Add(task1);

            //}
            //// call the method Create from WebAPIAsync
            //WebAPIAsync<StationTask> taskWebApi = new WebAPIAsync<StationTask>().Create(task);


            //var tasks = new WebAPIAsync<StationTask>().Load();//need to be continue
            //TaskViewModel.TaskCatalog.Tasks.Clear();
            //foreach (var Taskss in tasks)
            //{
            //    TaskViewModel.TaskCatalog.Tasks.Add(Taskss);
            //}


        }

        public async void DeleteTask()
        {

            Task1 task = new Task1();
            task.TaskId = TaskViewModel.SelectedTask.TaskId;
            await new TaskWebAPI().DeleteTask(task.TaskId);
            TaskViewModel.Tasks.Remove(TaskViewModel.SelectedTask);
        }













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
