using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    class Comment
    {
        public int ID { get; set; }
        public int LogID { get; set; }
        public int UserID { get; set; }
        public DateTime time { get; set; }
        public string comment { get; set; }

        public Comment(int id, int logId, int userId, DateTime time, string comment )
        {
            ID = id;
            LogID = logId;
            UserID = userId;
            this.time = time;
            this.comment = comment;
        }

        public Comment()
        {
            
        }

        public override string ToString()
        {
            return $"{comment} (written by user with ID {ID}, on {time})";

        }
    }
}
