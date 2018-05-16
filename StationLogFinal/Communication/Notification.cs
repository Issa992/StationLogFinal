using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Communication
{
     class Notification : INotification
    {
        public int ID;
        public int stationID;
        public DateTime deadline;
        public string message;
        public bool isRed;

        public Notification(int id, int stationid, DateTime date,
            string mess)
        {
            this.ID = id; this.stationID = stationid;
            this.deadline = date; this.message = mess;
            isRed = false;
        }
        public int getID()
        {
            return ID;
        }

        public void MarkAsRed()
        {
            isRed = true;
        }
    }
}
