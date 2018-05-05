using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    public class Comment: IServable
    {
        private int ID;
        private int LogID;
        private int UserID;
        public DateTime date { get; set; }
        private string _comment;


        public void AddLog()
        {
            
        }

        public void GetDayLog(DateTime date)
        {
            
        }
    }
}
