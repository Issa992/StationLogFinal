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
        //oldDB http://stationlogwebapplication120180426012243.azurewebsites.net
        //newDB http://stationlogsystemwebapplication20180521105958.azurewebsites.net

        const string ServerUrl = "http://stationlogwebapplication120180521125426.azurewebsites.net";
        const string ApiPrefix = "api";
        const string ApiId = "Comments";
        WebAPIAsync<Comment> CommentWebApi = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);
        private IWebAPIAsync<Comment> iWebApiAsync;
        //asdsadsadasd
        public async void AddComment()
        {

            try
            {
                WebAPITest<Comment> CommentTester = new WebAPITest<Comment>(CommentWebApi);


                comment = new Comment
                {
                CommentId = CommentsViewM.NewComment.CommentId,
                CommentDate = CommentsViewM.NewComment.CommentDate,
                Description = CommentsViewM.NewComment.Description,
                UserId = CurrentSessioncs.GetCurrentUser().UserId,
               
                };
             
                await CommentTester.RunAPITestCreate(comment);
            }
            catch (Exception exception)
            {
                MessageDialog dialog = new MessageDialog(exception.ToString());
            }
            
            

        }


        public async void DeleteComment()
        { 
            CommentsViewM.CommentsOC.Remove(CommentsViewM.SelectedComment);
            iWebApiAsync = new WebAPIAsync<Comment>(ServerUrl, ApiPrefix, ApiId);


            await iWebApiAsync.Delete(CommentsViewM.SelectedComment.CommentId);
        }

        public CommentsHanlder(CommentsViewModel commentsViewModel)
        {
            CommentsViewM = commentsViewModel;
        }
    }
}
