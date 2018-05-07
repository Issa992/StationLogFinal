using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StationLogFinal.Annotations;
using StationLogFinal.Common;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using Task = System.Threading.Tasks.Task;

namespace StationLogFinal.ViewModel
{
    class TaskViewModel:NotifyPropertyChange
    {

        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";

        static IWebAPIAsync<Task1> iWebApiAsync = new WebAPIAsync<Task1>(ServerUrl, ApiPrefix, ApiId);

        //public Task1 AddNewTask { get; set; }

        private static ObservableCollection<Task1> _TasksColllection;


        public static Task1 _SelectedTask;
        private Task1 _newTask;
        public TaskHandler TaskHandler { get; set; }

        public  ObservableCollection<Task1> TasksColllection
        {
            get=>_TasksColllection;
            set
            {
                TasksColllection = value;
                OnPropertyChanged(nameof(TasksColllection));

            }
        }
    
        public Task1 NewTask
        {
            get { return _newTask; }
            set { _newTask = value; OnPropertyChanged(); }
        }

       

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TaskViewModel()
        {
            LoadTasks();

            NewTask = new Task1();
            TaskHandler= new TaskHandler(this);

          
            CreateCommand = new RelayCommand(TaskHandler.CreateTask);
            DeleteCommand = new RelayCommand(TaskHandler.DeleteTask);
            //AddNewTask=new Task1();

            DateTime d = DateTimeConverter .DTOfset(NewTask.Date);
           
           




        }

        public Task1 SelectedTask
        {
            get => _SelectedTask;
            set
            {
                _SelectedTask = value; OnPropertyChanged(nameof(SelectedTask));

            }
        }
        public  async Task<string> LoadTasks()
        {



           _TasksColllection = new ObservableCollection<Task1>(await iWebApiAsync.Load());


            //foreach (var tasks in TasksColllection)
            //{
            //    TasksColllection.Add(tasks);
            //}

            return "succes";
        }




    }
    public class DateTimeConverter
    {
        public static DateTime DTOfset(DateTimeOffset date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
    }

}
