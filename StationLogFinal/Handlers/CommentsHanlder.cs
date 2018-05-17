using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using StationLogFinal.Model;
using StationLogFinal.Persistency;
using StationLogFinal.SessionTools;
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

            try
            {
                WebAPITest<Comment> CommentTester = new WebAPITest<Comment>(CommentWebApi);


                comment = new Comment
                {
                    CommentDate = DateTime.Now,
                    CommentId = CommentsViewM.NewComment.CommentId, //auto Id
                    Description = CommentsViewM.NewComment.Description,
                    UserId = CurrentSessioncs.GetCurrentUser().UserId,
                    User = CurrentSessioncs.GetCurrentUser(),
                    Log = new Log(),
                    LogId = 0



                };
                CommentsViewM.CommentsOC.Add(comment);
                await CommentTester.RunAPITestCreate(comment);
            }
            catch (Exception exception)
            {
                MessageDialog dialog = new MessageDialog(exception.ToString());
            }
            
            

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
