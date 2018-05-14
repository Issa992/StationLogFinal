using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Communication
{
    class Alert : INotification
    {
        public int ID;
        public int stationID;
        public DateTime deadline;
        public string message;
        public bool isRed;
        public bool isToggled;

        public Alert (int id, int stationid, DateTime date, string mes,
            bool toggled)
        {
            ID = id; stationID = stationid;
            deadline = date; message = mes;
            isRed = false; isToggled = toggled;
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
