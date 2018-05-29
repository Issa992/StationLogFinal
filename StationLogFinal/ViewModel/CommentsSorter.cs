using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationLogWebApplication1;

namespace StationLogFinal.ViewModel
{
   static class CommentsSorter
    {
        static CommentsViewModel VM = new CommentsViewModel();
        public static List<Comment> SortMeasurmentsByDate(DateTime date)
        {
            var query = from measure in VM.CommentsOC where (measure.CommentDate == date) select measure;
            return query.ToList();
        }
     

        public static List<Comment> SortMeasurmentsByUser(int userId)
        {

            var query = from measure in VM.CommentsOC where (measure.UserId == userId) select measure;
            return query.ToList();
        }


    }
}
