using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using myGenericDBEFandWSMovies;
using StationLogFinal.Annotations;
using StationLogFinal.Common;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using Task = System.Threading.Tasks.Task;

namespace StationLogFinal.ViewModel
{
    class TaskViewModel:NotifyPropertyChange
    {

        public TaskWebAPI taskWebApi;

        public static Task1 _SelectedTask;
        private Task1 _newTask;
        public TaskHandler TaskHandler { get; set; }

        public Task1 NewTask
        {
            get { return _newTask; }
            set { _newTask = value; OnPropertyChanged(); }
        }

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TaskViewModel()
        {
           
            taskWebApi = new TaskWebAPI();
            Load();

            NewTask = new Task1();
            TaskHandler= new TaskHandler(this);

            Tasks = new ObservableCollection<Task1>();

            CreateCommand = new RelayCommand(TaskHandler.CreateTask);
            DeleteCommand = new RelayCommand(TaskHandler.DeleteTask);

            //Tasks.Add(new Task1());
            DateTime d = Converter.DateTimeConverter.DTOfset(NewTask.Date);

            


        }

        public Task1 SelectedTask
        {
            get => _SelectedTask;
            set
            {
                _SelectedTask = value; OnPropertyChanged(nameof(SelectedTask));

            }
        }
        public ObservableCollection<Task1> Tasks { get; set; }

        public async void Load()
        {
 

            var tasks = await taskWebApi.GetTaskAsync();
            if (tasks != null)
            {
                foreach (var t in tasks)
                {
                    Tasks.Add(t);
                }

            }

        }

      
    }

}
