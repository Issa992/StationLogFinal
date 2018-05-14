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
using StationLogWebApplication1;
using Task = System.Threading.Tasks.Task;

namespace StationLogFinal.ViewModel
{
    class TaskViewModel:NotifyPropertyChange
    {

        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";

        static IWebAPIAsync<TaskModel> iWebApiAsync = new WebAPIAsync<TaskModel>(ServerUrl, ApiPrefix, ApiId);

        //public Task1 AddNewTask { get; set; }

        private static ObservableCollection<TaskModel> _TasksColllection { get; set; }


        public static TaskModel _SelectedTask;
        private TaskModel _newTask;
        public TaskHandler TaskHandler { get; set; }
        //Working 
        //public ObservableCollection<Task1> TasksColllection
        //{
        //    get => _TasksColllection;
        //    set
        //    {
        //        TasksColllection = value;
        //        OnPropertyChanged(nameof(TasksColllection));

        //    }
        //}
        public ObservableCollection<TaskModel> TasksColllection
        {
            get => _TasksColllection;
            set
            {
                TasksColllection = value;
                OnPropertyChanged(nameof(TasksColllection));

            }
        }

        public TaskModel NewTask
        {
            get { return _newTask; }
            set { _newTask = value; OnPropertyChanged(); }
        }

       

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TaskViewModel()
        {
            //Refresh();
          
            LoadTasks();
            NewTask = new TaskModel();
            TaskHandler= new TaskHandler(this);

            CreateCommand = new RelayCommand(TaskHandler.CreateTask);
            DeleteCommand = new RelayCommand(TaskHandler.DeleteTask);
            //AddNewTask=new Task1();

            
            






        }

        public TaskModel SelectedTask
        {
            get => _SelectedTask;
            set
            {
                _SelectedTask = value; OnPropertyChanged(nameof(SelectedTask));

            }
        }
        public  async Task<string> LoadTasks()
        {



           _TasksColllection = new ObservableCollection<TaskModel>(await iWebApiAsync.Load());


            //foreach (var tasks in TasksColllection)
            //{
            //    TasksColllection.Add(tasks);
            //}

            return "succes";
        }


        public void Refresh()
        {
           //_TasksColllection.Clear();
            TasksColllection.Clear();

        }

    }
 
   

}
