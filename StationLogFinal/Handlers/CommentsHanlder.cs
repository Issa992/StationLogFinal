using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;

namespace StationLogFinal.Handlers
{
    class CommentsHanlder
    {
        private Comment comment;
        private IWebAPIAsync<Comment> iWebApiAsync;
        public CommentsViewModel CommentsViewM { get; set; }


        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net";
        const string ApiPrefix = "api";
        const string ApiId = "Comments";
        WebAPIAsync<Comment> CommentWebApi = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);

        public async void AddComment()
        {
            WebAPITest<Comment> CommentTester = new WebAPITest<Comment>(CommentWebApi);

          
            comment = new Comment(123, 333, 12313, new DateTime(2018, 01, 12), "asdsadasda", new User(),
                new LogClass());
            CommentsViewM.CommentsOC.Add(comment);
            await CommentTester.RunAPITestCreate(comment);

            //await iWebApiAsync.Create(comment);

        }


        public async void DeleteComment()
        {
            WebAPITest<Comment> CommentTester = new WebAPITest<Comment>(CommentWebApi);
            await CommentTester.RunAPITestDelete(CommentsViewM.SelectedComment.CommentId);

        }

        public CommentsHanlder(CommentsViewModel commentsViewModel)
        {
            CommentsViewM = commentsViewModel;
        }
    }
}
