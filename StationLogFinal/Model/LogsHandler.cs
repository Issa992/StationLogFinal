using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    public class LogsHandler
    {
        private Comment comment;
        public List<Comment> ShowDate;

        public void ShowByDate(DateTime time)
        {
           var result = ShowDate.Find(x => x.date == time);
            ShowDate = new List<Comment> {result};
        }

    }
}
