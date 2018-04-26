using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StationLogFinal.Annotations;
using StationLogFinal.Model;
using Task = System.Threading.Tasks.Task;

namespace StationLogFinal.ViewModel
{
    class TaskViewModel:INotifyPropertyChanged
    {
        public static StationTask _SelectedHotel;
        private StationTask _newTask;
        public TaskHandler TaskHandler { get; set; }

        public StationTask NewTask
        {
            get { return _newTask; }
            set { _newTask = value;OnPropertyChanged(); }
        }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TaskViewModel()
        {
            NewTask=new StationTask();
            TaskHandler=new TaskHandler(this);
            CreateCommand=new RelayCommand(TaskHandler.CreateTask);
            DeleteCommand=new RelayCommand(TaskHandler.DeleteTask);
            TaskHandler.CreateTask();
        }

        public StationTask SelectedTask
        {
            get => _SelectedHotel;
            set
            {
                _SelectedHotel = value; OnPropertyChanged(nameof(SelectedTask));

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
