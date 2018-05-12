using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    class Comment
    {
        public int CommentId { get; set; }
        public int LogId { get; set; }
        public int UserId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public LogClass Log { get; set; }

        public Comment(int id, int logId, int userId, DateTime time, string comment, User user, LogClass log)
        {
            CommentId = id;
            this.LogId = logId;
            UserId = userId;
            this.CommentDate = time;
            this.Description = comment;
            User = user;
            Log = log;
        }

        public Comment()
        {
            
        }

        public override string ToString()
        {
            return $"{Description} (written by user with ID {UserId}, on {CommentDate})";

        }
    }
}
