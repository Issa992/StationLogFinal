using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.ViewModel;
using StationLogWebApplication1;

namespace StationLogFinal.Handlers
{
    class CommentsHanlder
    {
        private Comment comment;
       
        public CommentsViewModel CommentsViewM { get; set; }


        const string ServerUrl = "http://stationlogwebapplication120180426012243.azurewebsites.net";
        const string ApiPrefix = "api";
        const string ApiId = "Comments";
        WebAPIAsync<Comment> CommentWebApi = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
        //asdsadsadasd
        public async void AddComment()
        {
            WebAPITest<Comment> CommentTester = new WebAPITest<Comment>(CommentWebApi);


            comment = new Comment
            {
                CommentDate = DateTime.Now,
                CommentId = CommentsViewM.NewComment.CommentId, //auto Id
                Description = CommentsViewM.NewComment.Description,
                UserId = CommentsViewM.NewComment.UserId,
                //User = currently logged user?


            };
            CommentsViewM.CommentsOC.Add(comment);
            await CommentTester.RunAPITestCreate(comment);
            

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
