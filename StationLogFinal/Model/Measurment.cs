using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationLogFinal.Model
{
    class Measurment
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public int MonitorID { get; set; }
        public string unit { get; set; }
        public int UserID { get; set; }
        public DateTime date { get; set; }

        public Measurment(int id, string description, double value, int monitorId, string unit, int userId, DateTime dateTime)
        {
            ID = id;
            Description = description;
            Value = value;
            MonitorID = monitorId;
            this.unit = unit;
            UserID = userId;
            date = dateTime;


        }

        public Measurment()
        {
            
        }
        public override string ToString()
        {
            return $"MeasurmentId: {ID} Description: {Description} Value {Value} unit {unit} MonitorId:{MonitorID} UserId:{UserID}";

        }
    }
}
