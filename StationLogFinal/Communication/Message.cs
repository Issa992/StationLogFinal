﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Communication
{
    class PMessage
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        private string message;
        public DateTime CreationTime;
        bool isRed;

        public PMessage (int id, int senderid, int receiverid,
            string message)
        {
            ID = id;
            SenderID = senderid;
            ReceiverID = receiverid;
            this.message = message;
            isRed = false;
        }
        

    }
}