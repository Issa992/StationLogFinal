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


namespace StationLogFinal.ViewModel
{
    class LogsViewModel: NotifyPropertyChange
    {
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CreateCommentCommand { get; set; }
        public ICommand DeleteCommentCommand { get; set; }
        public ObservableCollection<Measurment> Measurments { get; set; }
        public ObservableCollection<Comment> Comments { get; set; }

        private Measurment _NewMeasurment;
        private Comment _newComment;

        public LogsHandler LogsHandler;
        public  Measurment _SelectedMeasurment;
        public  Comment _SelectedComment;

        public Measurment NewMeasurment
        { 
            get { return _NewMeasurment; }
            set
            {
                _NewMeasurment = value;
                OnPropertyChanged();
            }
        }
        public Comment NewComment
        { 
            get { return _newComment; }
            set
            {
                _newComment = value;
                OnPropertyChanged();
            }
        }


        public Comment SelectedComment
        {
            get => _SelectedComment;
            set
            {
                _SelectedComment = value;
                OnPropertyChanged(nameof(SelectedComment));
            }
        }
        public Measurment SelectedMeasurment
        {
            get => _SelectedMeasurment;
            set
            {
                _SelectedMeasurment = value;
                OnPropertyChanged(nameof(SelectedMeasurment));
            }
        }

        public LogsViewModel()
        {
            NewMeasurment = new Measurment();
            NewComment = new Comment();
            LogsHandler = new LogsHandler(this);
            Measurments = new ObservableCollection<Measurment>();
            Comments = new ObservableCollection<Comment>();
            CreateCommand = new RelayCommand(LogsHandler.AddMeasurment);
            DeleteCommand = new RelayCommand(LogsHandler.DeleteMeasurment);
            CreateCommentCommand = new RelayCommand(LogsHandler.AddComment);
            DeleteCommentCommand = new RelayCommand(LogsHandler.DeleteComment);

            
           
            
        }
    }
}
