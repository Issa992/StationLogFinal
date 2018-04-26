using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using myGenericDBEFandWSMovies;
using Newtonsoft.Json;
using StationLogFinal.ViewModel;

namespace StationLogFinal.Model
{
    class TaskHandler
    {
        //
        const string serverURL = "http://localhost:65531/";
        const string taskURI = "Tables";
        const string apiPrefix = "api";
        public TaskViewModel TaskViewModel { get; set; }

        public TaskHandler(TaskViewModel taskViewModel)
        {
            TaskViewModel = TaskViewModel;
        }
        public ObservableCollection<StationTask> taskss { get; set; }
        public async void CreateTask()
        {
            //StationTask task=new StationTask();
            //task._TaskId = TaskViewModel.NewTask._TaskId;
            //task._DateTime = TaskViewModel.NewTask._DateTime;
            //task._Description = TaskViewModel.NewTask._Description;
            //task._IsDone = TaskViewModel.NewTask._IsDone;
            //task._IsRepeatable = TaskViewModel.NewTask._IsRepeatable;
            //task._SchduledDate = TaskViewModel.NewTask._SchduledDate;
            //task._StationId = TaskViewModel.NewTask._StationId;
            //task._UserId = TaskViewModel.NewTask._UserId;
            WebAPIAsync<StationTask> taskWebApi = new WebAPIAsync<StationTask>(serverURL, apiPrefix, taskURI);
            WebAPITest<StationTask> taskWebApiTester = new WebAPITest<StationTask>(taskWebApi);
            await taskWebApiTester.RunAPITestLoad();
            taskss =new ObservableCollection<StationTask>();

        }

        public void DeleteTask()
        {

        }









        private ObservableCollection<Task> tasksList;

        private string url;

        public TaskHandler()
        {
            tasksList = new ObservableCollection<Task>();
        }

        public void CreateTask(Task task)
        {
            if (task != null)
            {
                tasksList.Add(task);
            }
           
        }

        //public void DeleteTask(int taskID)
        //{
        //    foreach (var task in tasksList)
        //    {
        //        if (task.ID == taskID)
        //        {
        //            tasksList.Remove(task);
        //        }
        //    }
        //}

        //redo : adding comment to already existing task

        //public void UpadateTask(int taskId)
        //{
        //    var task = tasksList.Where(d => d.taskID == taskId).FirstOrDefault();
        //    if (task != null)
        //    {
        //        //change values...
        //        //task.Name = "a new name";

        //    }
        //}

        public Task GetTask(int taskId)
        {
            return tasksList[taskId];
        }

        //public void MakeTaskDone(int taskId)
        //{
        //    if (tasksList[taskId].IsDone != true)
        //    tasksList[taskId].IsDone = true;
        //}
     

    }
}
