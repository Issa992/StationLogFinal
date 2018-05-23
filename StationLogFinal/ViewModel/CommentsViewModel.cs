using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StationLogFinal.Common;
using StationLogFinal.Handlers;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel
{
    class CommentsViewModel : NotifyPropertyChange
    {
        public CommentsHanlder commentsHanlder;

        private Comment _newComment;
        public Comment _SelectedComment;
        public ICommand CreateCommentCommand { get; set; }
        public ICommand DeleteCommentCommand { get; set; }
        
        const string ServerUrl = "http://stationlogsystemwebapplication20180521105958.azurewebsites.net";
        const string ApiPrefix = "api";
        const string ApiId = "Comments";

        public static IWebAPIAsync<Comment> iWebApiAsync = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
        WebAPIAsync<Comment> CommentWebApi = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
        private static ObservableCollection<Comment> _CommentsOC;

        public  ObservableCollection<Comment> CommentsOC
        {
            get => _CommentsOC;
            set
            {
                CommentsOC = value;
                OnPropertyChanged(nameof(CommentsOC));

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

        public async Task<int> LoadComments()
        {
            _CommentsOC = new ObservableCollection<Comment>(await iWebApiAsync.Load());
            return 1;
        }

       
        public CommentsViewModel()
        {
         
            NewComment = new Comment();
            LoadComments();
            commentsHanlder = new CommentsHanlder(this);
            CreateCommentCommand = new RelayCommand(commentsHanlder.AddComment);
            DeleteCommentCommand = new RelayCommand(commentsHanlder.DeleteComment);
        }



    }
}
