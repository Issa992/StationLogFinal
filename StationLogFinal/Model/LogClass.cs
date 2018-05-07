using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    class LogClass
    {
        private DateTime time;
        private int ID;
        private string Name;
        private string Type;
        private int UserID;
        private int StationID;

        public LogClass(DateTime Time, int id, string name, string type, int userId, int stationId)
        {
            time = Time;
            ID = id;
            Name = name;
            Type = type;
            UserID = userId;
            StationID = stationId;


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
