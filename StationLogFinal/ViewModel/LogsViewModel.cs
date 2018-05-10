using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogWebApplication1;

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


        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net/";
        const string ApiPrefix = "api";
        const string ApiId = "Comments";

        static IWebAPIAsync<Comment> iWebApiAsync = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);

        private static ObservableCollection<Comment> _CommentsOC;

        public ObservableCollection<Comment> CommentsOC
        {
            get => _CommentsOC;
            set
            {
                CommentsOC = value;
                OnPropertyChanged(nameof(CommentsOC));

            }
        }

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

        public async Task<ObservableCollection<Comment>> LoadComments()
        {
           _CommentsOC = new ObservableCollection<Comment>(await iWebApiAsync.Load());
            return _CommentsOC;
        }


        public LogsViewModel()
        {
            CommentsOC = new ObservableCollection<Comment>();
            NewMeasurment = new Measurment();
            NewComment = new Comment();
            //LogsHandler = new LogsHandler(this);
            Measurments = new ObservableCollection<Measurment>();
            Comments = new ObservableCollection<Comment>();
            //CreateCommand = new RelayCommand(LogsHandler.AddMeasurment);
            //DeleteCommand = new RelayCommand(LogsHandler.DeleteMeasurment);
            //CreateCommentCommand = new RelayCommand(LogsHandler.AddComment);
            //DeleteCommentCommand = new RelayCommand(LogsHandler.DeleteComment);
            LoadComments();



        }
    }
}
