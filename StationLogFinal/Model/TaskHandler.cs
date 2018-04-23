using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StationLogFinal.Model
{
    class TaskHandler
    {
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
