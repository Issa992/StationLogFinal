namespace StationLogWebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Measurement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MeasurementId { get; set; }

        public int MonitorId { get; set; }

        public int UserId { get; set; }

        public int StationId { get; set; }

        public DateTime Date { get; set; }

        public DateTimeOffset DateOffset
        {
            get { return DateTime.SpecifyKind(Date, DateTimeKind.Utc); }
            set { Date = value.DateTime; }
        }

        [Required]
        public string Description { get; set; }

        public int Value { get; set; }

        public virtual Monitor Monitor { get; set; }

        public virtual User User { get; set; }

        public virtual Station Station { get; set; }

        public Measurement(int measurementId, int monitorId, int userId, int stationId, DateTime date, string description, int value)
        {
            MeasurementId = measurementId;
            MonitorId = monitorId;
            UserId = userId;
            StationId = stationId;
            Date = date;
            Description = description;
            Value = value;
        }

        public Measurement()
        {

        }

        public override string ToString()
        {
            return $"Measurement ID: {MeasurementId}, Value:{Value}, {Description}";
        }
    }
}
