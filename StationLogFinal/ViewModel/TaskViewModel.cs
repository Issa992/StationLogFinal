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
        //oldDB http://stationlogwebapplication120180426012243.azurewebsites.net
        //newDB http://stationlogsystemwebapplication20180521105958.azurewebsites.net

        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Tasks";

        static IWebAPIAsync<TaskModel> iWebApiAsync = new WebAPIAsync<TaskModel>(ServerUrl, ApiPrefix, ApiId);

        private static ObservableCollection<TaskModel> _TasksColllection { get; set; }


        public static TaskModel _SelectedTask;
        private TaskModel _newTask;
        public TaskHandler TaskHandler { get; set; }

        
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
        public ICommand UpdateCommand { get; set; }

        public TaskViewModel()
        {
            

            LoadTasks();
            NewTask = new TaskModel();
            TaskHandler= new TaskHandler(this);

            CreateCommand = new RelayCommand(TaskHandler.CheckFields);
            DeleteCommand = new RelayCommand(TaskHandler.DeleteTask);

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
            return "succes";
        }

    
        public void Refresh()
        {
           //_TasksColllection.Clear();
           _TasksColllection.Clear();

        }

    }
 
   

}
