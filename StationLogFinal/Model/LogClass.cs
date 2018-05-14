using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    class LogClass
    {
        public DateTime time { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int UserID { get; set; }
        public int StationID { get; set; }
        public int CommentID { get; set; }

        public LogClass(DateTime Time, int id, string name, string type, int userId, int stationId, int commentId )
        {
            time = Time;
            ID = id;
            Name = name;
            Type = type;
            UserID = userId;
            StationID = stationId;
            CommentID = commentId;


        }

        public LogClass()
        {
            
        }

        public override string ToString()
        {
            return $"LogId: {ID}  Name: {Name} Date: {time} Type: {Type} StationId:{StationID} UserId:{UserID}";

        }

    }
}
