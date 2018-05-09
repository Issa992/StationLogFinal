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
