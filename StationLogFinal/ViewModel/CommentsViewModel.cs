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
using StationLogFinal.SessionTools;
using StationLogFinal.Views;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel
{
    class CommentsViewModel : NotifyPropertyChange
    {
        #region fields
        public CommentsHanlder commentsHanlder;

        private Comment _newComment;
        public Comment _SelectedComment;
        public ICommand CreateCommentCommand { get; set; }
        public ICommand DeleteCommentCommand { get; set; }

        const string ServerUrl = "http://stationlogwebapplication120180521125426.azurewebsites.net";
        const string ApiPrefix = "api";
        const string ApiId = "Comments";

        public static IWebAPIAsync<Comment> iWebApiAsync = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
        WebAPIAsync<Comment> CommentWebApi = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
        private static ObservableCollection<Comment> _CommentsOC;
        private static ObservableCollection<Comment> _sortedComments;

        public ObservableCollection<Comment> CommentsOC
        {
            get => _CommentsOC;
            set
            {
                CommentsOC = value;
                OnPropertyChanged(nameof(CommentsOC));

            }
        }
        public ObservableCollection<Comment> SortedComments
        {
            get => _sortedComments;
            set
            {
                SortedComments = value;
                OnPropertyChanged(nameof(SortedComments));
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

        #endregion
        public void SortElementsByUser()
        {
            _sortedComments = new ObservableCollection<Comment>(
                CommentsSorter.SortCommentsByUser(HistoryView.ID));
        }

        public void SortElementsByDate()
        {
            _sortedComments = new ObservableCollection<Comment>(
                CommentsSorter.SortCommentsByDate(HistoryView.date));
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
